    [Flags]
    public enum SynchronizedScrollViewerMode
    {
        Horizontal = 0x1,
        Vertical = 0x2,
        HorizontalAndVertical = Horizontal | Vertical,
        Disabled = 0
    }
    public sealed class SynchronizedScrollViewer : DependencyObject
    {
        public SynchronizedScrollViewerMode Mode { get; }
        public VerticalAlignment VerticalAlignment { get; private set; }
        public HorizontalAlignment HorizontalAlignment { get; private set; }
        private class SyncrhonizedScrollViewerChild
        {
            public readonly ScrollViewer ScrollViewer;
            public bool IsDirty;
            public SyncrhonizedScrollViewerChild(ScrollViewer child)
            {
                if (child == null)
                {
                    throw new ArgumentNullException(nameof(child));
                }
                this.ScrollViewer = child;
            }
        }
        private readonly List<SyncrhonizedScrollViewerChild> Children;
        public SynchronizedScrollViewer(SynchronizedScrollViewerMode mode)
        {
            if (mode == SynchronizedScrollViewerMode.Disabled)
            {
                throw new ArgumentNullException(nameof(mode));
            }
            this.Mode = mode;
            this.Children = new List<SyncrhonizedScrollViewerChild>();
        }
        #region Attached Properties
        public static SynchronizedScrollViewerMode GetScopeMode(DependencyObject obj)
        {
            return (SynchronizedScrollViewerMode)obj.GetValue(ScopeModeProperty);
        }
        public static void SetScopeMode(DependencyObject obj, SynchronizedScrollViewerMode value)
        {
            obj.SetValue(ScopeModeProperty, value);
        }
        public static readonly DependencyProperty ScopeModeProperty =
            DependencyProperty.RegisterAttached("ScopeMode", typeof(SynchronizedScrollViewerMode),
                typeof(SynchronizedScrollViewer), new PropertyMetadata(SynchronizedScrollViewerMode.Disabled));
        public static HorizontalAlignment GetHorizontalAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(HorizontalAlignmentProperty);
        }
        public static void SetHorizontalAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(HorizontalAlignmentProperty, value);
        }
        public static readonly DependencyProperty HorizontalAlignmentProperty =
            DependencyProperty.RegisterAttached("HorizontalAlignment", typeof(HorizontalAlignment),
                typeof(SynchronizedScrollViewer), new PropertyMetadata(HorizontalAlignment.Left, Alignment_Changed));
        public static VerticalAlignment GetVerticalAlignment(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(VerticalAlignmentProperty);
        }
        public static void SetVerticalAlignment(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(VerticalAlignmentProperty, value);
        }
        public static readonly DependencyProperty VerticalAlignmentProperty =
            DependencyProperty.RegisterAttached("VerticalAlignment", typeof(VerticalAlignment),
                typeof(SynchronizedScrollViewer), new PropertyMetadata(VerticalAlignment.Top, Alignment_Changed));
        public static bool GetIsSynchronized(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSynchronizedProperty);
        }
        public static void SetIsSynchronized(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSynchronizedProperty, value);
        }
        public static readonly DependencyProperty IsSynchronizedProperty =
            DependencyProperty.RegisterAttached("IsSynchronized", typeof(bool),
                typeof(SynchronizedScrollViewer), new FrameworkPropertyMetadata(false, IsSynchronized_Changed));
        public static SynchronizedScrollViewer GetScope(DependencyObject obj)
        {
            return (SynchronizedScrollViewer)obj.GetValue(ScopeProperty);
        }
        public static void SetScope(DependencyObject obj, SynchronizedScrollViewer value)
        {
            obj.SetValue(ScopeProperty, value);
        }
        public static readonly DependencyProperty ScopeProperty =
            DependencyProperty.RegisterAttached("Scope", typeof(SynchronizedScrollViewer),
                typeof(SynchronizedScrollViewer), new PropertyMetadata(null));
        #endregion
        private static void Alignment_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scope = GetScope(d);
            if (scope == null)
            {
                // will be set later
            }
            else
            {
                scope.HorizontalAlignment = GetHorizontalAlignment(d);
                scope.VerticalAlignment = GetVerticalAlignment(d);
            }
        }
        private static void IsSynchronized_Changed(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var target = (ScrollViewer)d;
            var newValue = (bool)args.NewValue;
            if (newValue)
            {
                var scope = FindSynchronizationScope(target);
                scope.AddSynchronizedChild(target);
            }
        }
        private void AddSynchronizedChild(ScrollViewer target)
        {
            if (this.Children.Any(c => c.ScrollViewer == target))
            {
                throw new InvalidOperationException("Child is already synchronized");
            }
            this.Children.Add(new SyncrhonizedScrollViewerChild(target));
            target.ScrollChanged += Target_ScrollChanged;
        }
        private void Target_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var sv = (ScrollViewer)sender;
            var child = Children.Single(s => s.ScrollViewer == sv);
            if (child.IsDirty)
            {
                // we just called "Set*Offset" on this child, so we don't wan't a loop
                // no-op
                child.IsDirty = false;
            }
            else
            {
                foreach (var otherChild in Children)
                {
                    if (otherChild == child)
                    {
                        // don't update the sender
                        continue;
                    }
                    var osv = otherChild.ScrollViewer;
                    if (this.Mode.HasFlag(SynchronizedScrollViewerMode.Horizontal)
                        && otherChild.ScrollViewer.HorizontalOffset != child.ScrollViewer.HorizontalOffset)
                    {
                        // already in sync
                        otherChild.IsDirty = true;
                        var targetOffset = sv.HorizontalOffset;
                        if (HorizontalAlignment == HorizontalAlignment.Center
                            || HorizontalAlignment == HorizontalAlignment.Stretch)
                        {
                            double scrollPositionPct = sv.HorizontalOffset / (sv.ExtentWidth - sv.ViewportWidth);
                            targetOffset = (osv.ExtentWidth - osv.ViewportWidth) * scrollPositionPct;
                        }
                        else if (HorizontalAlignment == HorizontalAlignment.Right)
                        {
                            targetOffset = otherChild.ScrollViewer.ExtentWidth - (sv.ExtentWidth - sv.HorizontalOffset);
                        }
                        otherChild.ScrollViewer.ScrollToHorizontalOffset(targetOffset);
                    }
                    if (this.Mode.HasFlag(SynchronizedScrollViewerMode.Vertical)
                        && otherChild.ScrollViewer.VerticalOffset != child.ScrollViewer.VerticalOffset)
                    {
                        // already in sync
                        otherChild.IsDirty = true;
                        var targetOffset = sv.VerticalOffset;
                        if (VerticalAlignment == VerticalAlignment.Center
                            || VerticalAlignment == VerticalAlignment.Stretch)
                        {
                            double scrollPositionPct = sv.VerticalOffset / (sv.ExtentHeight - sv.ViewportHeight);
                            targetOffset = (osv.ExtentHeight - osv.ViewportHeight) * scrollPositionPct;
                        }
                        else if (VerticalAlignment == VerticalAlignment.Bottom)
                        {
                            targetOffset = otherChild.ScrollViewer.ExtentHeight - (sv.ExtentHeight - sv.VerticalOffset);
                        }
                        otherChild.ScrollViewer.ScrollToVerticalOffset(targetOffset);
                    }
                }
            }
        }
        private static SynchronizedScrollViewer FindSynchronizationScope(ScrollViewer target)
        {
            for (DependencyObject obj = target; obj != null;
                // ContentPresenter seems to cause VisualTreeHelper to return null when FrameworkElement.Parent works.
                // http://stackoverflow.com/questions/6921881/frameworkelement-parent-and-visualtreehelper-getparent-behaves-differently
                obj = VisualTreeHelper.GetParent(obj) ?? (obj as FrameworkElement)?.Parent)
            {
                var mode = GetScopeMode(obj);
                if (mode != SynchronizedScrollViewerMode.Disabled)
                {
                    var scope = GetScope(obj);
                    if (scope == null)
                    {
                        scope = new SynchronizedScrollViewer(mode);
                        scope.HorizontalAlignment = GetHorizontalAlignment(obj);
                        scope.VerticalAlignment = GetVerticalAlignment(obj);
                        SetScope(obj, scope);
                    }
                    return scope;
                }
            }
            throw new InvalidOperationException("A scroll viewer is set as synchronized, but no synchronization scope was found.");
        }
    }
