    public class CountryVm
    {
        public CountryVm()
        {
            ImageUri = new Uri("Resources/rgb.png", UriKind.Relative);            
        }
        public string Name { get; set; }
        public Uri ImageUri { get; set; }
    }
