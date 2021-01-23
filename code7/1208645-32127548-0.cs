    public object CurrentView { get; set; }
    
    private TiffImageViewerViewModel _TiffImageViewerViewModel;
        public TiffImageViewerViewModel TiffImageViewerViewModel
        {
            get
            {
                return _TiffImageViewerViewModel;
            }
            set
            {
                _TiffImageViewerViewModel = value;
            }
        }
