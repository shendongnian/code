    public class SqueezeStackPanel : Panel
    {
        private const double Tolerance = 0.001;
    
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register
            ("Orientation", typeof (Orientation), typeof (SqueezeStackPanel),
                new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure,
                    OnOrientationChanged));
    
        private readonly Dictionary<UIElement, Size> _childToConstraint = new Dictionary<UIElement, Size>();
        private bool _isMeasureDirty;
        private bool _isHorizontal = true;
        private List<UIElement> _orderedSequence;
        private Child[] _children;
    
        static SqueezeStackPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata
                (typeof (SqueezeStackPanel),
                    new FrameworkPropertyMetadata(typeof (SqueezeStackPanel)));
        }
    
        protected override bool HasLogicalOrientation
        {
            get { return true; }
        }
    
        protected override Orientation LogicalOrientation
        {
            get { return Orientation; }
        }
    
        public Orientation Orientation
        {
            get { return (Orientation) GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
    
        protected override Size ArrangeOverride(Size finalSize)
        {
            var size = new Size(_isHorizontal ? 0 : finalSize.Width, !_isHorizontal ? 0 : finalSize.Height);
    
            var childrenCount = Children.Count;
    
            var rc = new Rect();
            for (var index = 0; index < childrenCount; index++)
            {
                var child = _orderedSequence[index];
    
                var childVal = _children[index].Val;
                if (_isHorizontal)
                {
                    rc.Width = double.IsInfinity(childVal) ? child.DesiredSize.Width : childVal;
                    rc.Height = Math.Max(finalSize.Height, child.DesiredSize.Height);
                    size.Width += rc.Width;
                    size.Height = Math.Max(size.Height, rc.Height);
                    child.Arrange(rc);
                    rc.X += rc.Width;
                }
                else
                {
                    rc.Width = Math.Max(finalSize.Width, child.DesiredSize.Width);
                    rc.Height = double.IsInfinity(childVal) ? child.DesiredSize.Height : childVal;
                    size.Width = Math.Max(size.Width, rc.Width);
                    size.Height += rc.Height;
                    child.Arrange(rc);
                    rc.Y += rc.Height;
                }
            }
    
            return new Size(Math.Max(finalSize.Width, size.Width), Math.Max(finalSize.Height, size.Height));
        }
    
        protected override Size MeasureOverride(Size availableSize)
        {
            for (var i = 0; i < 3; i++)
            {
                _isMeasureDirty = false;
    
                var childrenDesiredSize = new Size();
    
                var childrenCount = Children.Count;
    
                if (childrenCount == 0)
                    return childrenDesiredSize;
    
                var childConstraint = GetChildrenConstraint(availableSize);
    
                _children = new Child[childrenCount];
    
                _orderedSequence = Children.Cast<UIElement>().ToList();
    
                for (var index = 0; index < childrenCount; index++)
                {
                    if (_isMeasureDirty)
                        break;
    
                    var child = _orderedSequence[index];
    
                    const double minLength = 0.0;
                    const double maxLength = double.PositiveInfinity;
    
                    MeasureChild(child, childConstraint);
    
                    if (_isHorizontal)
                    {
                        childrenDesiredSize.Width += child.DesiredSize.Width;
                        _children[index] = new Child(minLength, maxLength, child.DesiredSize.Width);
                        childrenDesiredSize.Height = Math.Max(childrenDesiredSize.Height, child.DesiredSize.Height);
                    }
                    else
                    {
                        childrenDesiredSize.Height += child.DesiredSize.Height;
                        _children[index] = new Child(minLength, maxLength, child.DesiredSize.Height);
                        childrenDesiredSize.Width = Math.Max(childrenDesiredSize.Width, child.DesiredSize.Width);
                    }
                }
    
                if (_isMeasureDirty)
                    continue;
    
                var current = _children.Sum(s => s.Val);
                var target = GetSizePart(availableSize);
    
                var finalSize = new Size
                    (Math.Min(availableSize.Width, _isHorizontal ? current : childrenDesiredSize.Width),
                        Math.Min(availableSize.Height, _isHorizontal ? childrenDesiredSize.Height : current));
    
                if (double.IsInfinity(target))
                    return finalSize;
    
                RecalcChilds(current, target);
    
                current = 0.0;
                for (var index = 0; index < childrenCount; index++)
                {
                    var child = _children[index];
    
                    if (IsGreater(current + child.Val, target, Tolerance) &&
                        IsGreater(target, current, Tolerance))
                    {
                        var rest = IsGreater(target, current, Tolerance) ? target - current : 0.0;
                        if (IsGreater(rest, child.Min, Tolerance))
                            child.Val = rest;
                    }
    
                    current += child.Val;
                }
    
                RemeasureChildren(finalSize);
    
                finalSize = new Size
                    (Math.Min(availableSize.Width, _isHorizontal ? target : childrenDesiredSize.Width),
                        Math.Min(availableSize.Height, _isHorizontal ? childrenDesiredSize.Height : target));
    
                if (_isMeasureDirty)
                    continue;
    
                return finalSize;
            }
    
            return new Size();
        }
    
        public static double GetHeight(Thickness thickness)
        {
            return thickness.Top + thickness.Bottom;
        }
    
        public static double GetWidth(Thickness thickness)
        {
            return thickness.Left + thickness.Right;
        }
    
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
    
            var removedUiElement = visualRemoved as UIElement;
    
            if (removedUiElement != null)
                _childToConstraint.Remove(removedUiElement);
        }
    
        private Size GetChildrenConstraint(Size availableSize)
        {
            return new Size
                (_isHorizontal ? double.PositiveInfinity : availableSize.Width,
                    !_isHorizontal ? double.PositiveInfinity : availableSize.Height);
        }
    
        private double GetSizePart(Size size)
        {
            return _isHorizontal ? size.Width : size.Height;
        }
    
        private static bool IsGreater(double a, double b, double tolerance)
        {
            return a - b > tolerance;
        }
    
        private void MeasureChild(UIElement child, Size childConstraint)
        {
            Size lastConstraint;
            if ((child.IsMeasureValid && _childToConstraint.TryGetValue(child, out lastConstraint) &&
                    lastConstraint.Equals(childConstraint))) return;
    
            child.Measure(childConstraint);
            _childToConstraint[child] = childConstraint;
        }
    
        private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = (SqueezeStackPanel) d;
            panel._isHorizontal = panel.Orientation == Orientation.Horizontal;
        }
    
        private void RecalcChilds(double current, double target)
        {
            var shouldShrink = IsGreater(current, target, Tolerance);
    
            if (shouldShrink)
                ShrinkChildren(_children, target);
        }
    
        private void RemeasureChildren(Size availableSize)
        {
            var childrenCount = Children.Count;
            if (childrenCount == 0)
                return;
    
            var childConstraint = GetChildrenConstraint(availableSize);
            for (var index = 0; index < childrenCount; index++)
            {
                var child = _orderedSequence[index];
                if (Math.Abs(GetSizePart(child.DesiredSize) - _children[index].Val) > Tolerance)
                    MeasureChild(child, new Size(_isHorizontal ? _children[index].Val : childConstraint.Width,
                        !_isHorizontal ? _children[index].Val : childConstraint.Height));
            }
        }
    
        private static void ShrinkChildren(IEnumerable<Child> children, double target)
        {
            var sortedChilds = children.OrderBy(v => v.Val).ToList();
            var minValidTarget = sortedChilds.Sum(s => s.Min);
            if (minValidTarget > target)
            {
                foreach (var child in sortedChilds)
                    child.Val = child.Min;
                return;
            }
            do
            {
                var tmpTarget = target;
                for (var iChild = 0; iChild < sortedChilds.Count; iChild++)
                {
                    var child = sortedChilds[iChild];
                    if (child.Val*(sortedChilds.Count - iChild) >= tmpTarget)
                    {
                        var avg = tmpTarget/(sortedChilds.Count - iChild);
                        var success = true;
                        for (var jChild = iChild; jChild < sortedChilds.Count; jChild++)
                        {
                            var tChild = sortedChilds[jChild];
                            tChild.Val = Math.Max(tChild.Min, avg);
    
                            // Min constraint skip success expand on this iteration
                            if (Math.Abs(avg - tChild.Val) <= Tolerance) continue;
    
                            target -= tChild.Val;
                            success = false;
                            sortedChilds.RemoveAt(jChild);
                            jChild--;
                        }
                        if (success)
                            return;
    
                        break;
                    }
                    tmpTarget -= child.Val;
                }
            } while (sortedChilds.Count > 0);
        }
    
        private class Child
        {
            public readonly double Min;
            public double Val;
    
            public Child(double min, double max, double val)
            {
                Min = min;
                Val = val;
    
                Val = Math.Max(min, val);
                Val = Math.Min(max, Val);
            }
        }
    }
