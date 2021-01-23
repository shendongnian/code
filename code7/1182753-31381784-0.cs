    public class DraggedAdorner : Adorner
    {
        private readonly Rectangle background;
        private readonly ContentPresenter draggedItemPresenter;
        private readonly AdornerLayer draggedItemAdornerLayer;
        private double left;
        private double top;
        
        /// <summary>
        /// Initializes a new adorner, which will display the dragged listbox-item.
        /// </summary>
        /// <param name="listBoxItem">ListBoxItem, which we want to show while dragging.</param>
        /// <param name="listBox">ListBoxItem, which we want to show while dragging.</param>
        /// <param name="adornerLayer">Presentation layer for the adorner.</param>
        /// <param name="width"></param>
        public DraggedAdorner(ListBoxItem listBoxItem, ListBox listBox, AdornerLayer adornerLayer, double width, double height)
            : base(listBox)
        {
            draggedItemAdornerLayer = adornerLayer;            
            draggedItemPresenter = new ContentPresenter
            {
                Content = listBoxItem,
                Width = width,
                Height = height
            };
            Rectangle rectangle = new Rectangle
                {
                    Width = width,
                    Height = height,
                    Fill = new SolidColorBrush(Colors.SkyBlue)
                };
            background = rectangle;
            draggedItemAdornerLayer.Add(this);
        }
        /// <summary>
        /// Sets the position of the dragged adorner.
        /// </summary>
        /// <param name="newLeft">new left position of the adorner</param>
        /// <param name="newTop">new top position of the adorner</param>
        public void SetPosition(double newLeft, double newTop)
        {
            //only set the left property the first time, to not allow dragging the listboxitem
            //out of the listbox in the horizontal direction.
            if (Math.Abs(left) < 0.1)
            {
                left = newLeft + 20;
            }
            top = newTop;
            if (draggedItemAdornerLayer != null)
            {
                draggedItemAdornerLayer.Update(AdornedElement);
            }
        }
        protected override Size MeasureOverride(Size constraint)
        {
            draggedItemPresenter.Measure(constraint);
            background.Measure(constraint);
            return draggedItemPresenter.DesiredSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            draggedItemPresenter.Arrange(new Rect(finalSize));
            background.Arrange(new Rect(finalSize));
            return finalSize;
        }
        protected override Visual GetVisualChild(int index)
        {
            return index == 0 ? (Visual) background : draggedItemPresenter;
        }
        protected override int VisualChildrenCount
        {
            get { return 2; }
        }
        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(left, top));
            return result;
        }
        /// <summary>
        /// Removes the this adorner form the adornerlayer.
        /// </summary>
        public void Detach()
        {
            draggedItemAdornerLayer.Remove(this);
        }
    }
