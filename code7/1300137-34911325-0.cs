    public class NexusCanvas : Canvas
    {
        private Point? dragStartPoint = null;
    
    
        // attempt to combine scrollview and canvas into one
        public ScrollViewer ScrollViewer
        {
            get { return (ScrollViewer)GetValue(ScrollViewerProperty); }
            set { SetValue(ScrollViewerProperty, value); }
        }
        public static readonly DependencyProperty ScrollViewerProperty =
            DependencyProperty.Register("ScrollViewer", typeof(ScrollViewer), typeof(NexusCanvas));
    }
