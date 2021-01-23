    public class CustomScrollViewer : ScrollViewer
    {
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            ((e.Source as FrameworkElement).Parent as UIElement).RaiseEvent(e);
        }
    }
