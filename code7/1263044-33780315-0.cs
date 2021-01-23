    public class StaticImageViewModel
    {
        private static readonly Lazy<StaticImageViewModel> Lazy = new Lazy<StaticImageViewModel>(() => new StaticImageViewModel());
        private List<BitmapImage> images;
        private StaticImageViewModel()
        {
            this.images = new List<BitmapImage>
                {
                    new BitmapImage(new Uri("pack://application:,,,/<namespace_here>;component/Images/Image1.png"))
                };
        }
        public static StaticImageViewModel Instance
        {
            get { return Lazy.Value; }
        }
        public BitmapImage Image
        {
            get
            {
                return this.images[0];
            }
        }
    }
	
