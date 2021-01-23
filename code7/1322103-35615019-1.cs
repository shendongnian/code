    [TemplatePart(Name = "ScrollViewer", Type = typeof(ScrollViewer))]
    public class ZoomBox : Control
    {
        private ScrollViewer _scrollViewerPart;
        public override void OnApplyTemplate()
        {
            _scrollViewerPart = GetTemplateChild("ScrollViewer") as ScrollViewer;
        }
        public ScrollViewer GetScrollViewer()
        {
            return _scrollViewerPart;
        }
    }
