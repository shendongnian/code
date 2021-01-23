    namespace MapApper
    {
        public sealed partial class MainPage : Page
        {
            // private double latitude, longitude; // comment this
            public MainPage()
            {
                this.InitializeComponent();
    
                this.NavigationCacheMode = NavigationCacheMode.Required;
            }
            private async void GetRouteAndDirections(double latitude, double longitude)
            {
                //... your code
                endLocation.Latitude = latitude;
                endLocation.Longitude = longitude;
                //... your code
            }
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                //... your code
                show s = (show)e.Parameter;
                // latitude = s.latitude; // comment this
                // longitude = s.longitude; // comment this
                GetRouteAndDirections((double)s.latitude, (double)s.longitude); // you might want to cast the lat and lon as double
                //... your code
            }
            //... your code
        }
    }
