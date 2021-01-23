        public MainPage()
        {
            InitializeComponent();
        }
        private async Task ShowMyLocationOnTheMap(GeoPositionAccuracy accuracy)
        {
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            App.lat = myGeoCoordinate.Latitude;
            App.lng = myGeoCoordinate.Longitude;
            this.pushPin(this.mapWithMyLocation, myGeoCoordinate);
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ShowMyLocationOnTheMap(GeoPositionAccuracy.Default);
            webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
            string jsonQuery= "www.blabla.com?lat="+App.lat+"&lng="+App.lng;
            webClient.DownloadStringAsync(new Uri(jsonQuery));
        }
