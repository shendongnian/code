    public class ExtendedDataGrid : DataGrid
    {
        public event ScrollChangedEventHandler ScrollChanged;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var scrollViewer = (ScrollViewer)GetTemplateChild("DG_ScrollViewer");
            scrollViewer.ScrollChanged += OnScrollChanged;
        }
        protected virtual void OnScrollChanged(ScrollChangedEventArgs e)
        {
            ScrollChangedEventHandler handler = ScrollChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            OnScrollChanged(e);
        }
    }
