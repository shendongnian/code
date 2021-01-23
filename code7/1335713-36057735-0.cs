      internal void UnFreeze()
        {
            _pdfViewer.SetZoomEnabled(true);
            _pdfViewer.SetScrollEnabled(true);
        }
        public void Freeze()
        {
            _pdfViewer.SetZoomEnabled(false);
            _pdfViewer.SetScrollEnabled(false);
        }
