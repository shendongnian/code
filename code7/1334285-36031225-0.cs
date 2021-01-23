    class MyViewModel: NotificationBase
    {
        private MediaCapture _mediaCapture;
        public MediaCapture MediaCapture
        {
            get
            {
                if (_mediaCapture == null) _mediaCapture = new MediaCapture();
                return _mediaCapture;
            }
            set
            { 
                _mediaCapture = value;
            }
        }
        private CaptureElement _captureElement;
        public CaptureElement CaptureElement
        {
            get
            {
                if (_captureElement == null) _captureElement = new CaptureElement();
                return _captureElement;
            }
            set
            {               
                _captureElement = value;
            }
        }
        public MyViewModel()
        {
            ConfigureMedia();
        }
        private async void ConfigureMedia()
        {
            await MediaCapture.InitializeAsync();
            CaptureElement.Source = MediaCapture;
            await MediaCapture.StartPreviewAsync();
        }
    }
    
