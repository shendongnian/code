    public sealed class SubControlsTouchScrollEvent : Behavior<UIElement>
    {
        double originalDistance;
        double actualDistance;
        int delta;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTouchDown += AssociatedObject_PreviewTouchDown;
            AssociatedObject.PreviewTouchMove += AssociatedObject_PreviewTouchMove;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.PreviewTouchUp -= AssociatedObject_PreviewTouchDown;
            AssociatedObject.PreviewTouchMove -= AssociatedObject_PreviewTouchMove;
            base.OnDetaching();
        }
        
        void AssociatedObject_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            System.Windows.IInputElement s = sender as System.Windows.IInputElement;
            originalDistance = e.GetTouchPoint(s).Position.Y;
        }
        void AssociatedObject_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            ScrollViewer s = sender as ScrollViewer;
            actualDistance = e.GetTouchPoint(s).Position.Y;
            delta = Convert.ToInt16(actualDistance - originalDistance);          
            s.ScrollToVerticalOffset(s.VerticalOffset - (delta * 0.1));
            e.Handled = true;
        }
    }
