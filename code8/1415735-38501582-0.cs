    class FramesViewModel
    {
        public BitmapImage FrameImage { get; set; } = new BitmapImage();
        
    
        private static List<FramesViewModel> framesCollection = new List<FramesViewModel>
    {
        new FramesViewModel() { FrameImage = new BitmapImage(new Uri("http://www.citgroup.in/images/icon/wcf.png"))},
        
    };
        public static List<FramesViewModel> FramesCollection => framesCollection;
    
    }
