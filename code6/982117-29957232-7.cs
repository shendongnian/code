_lastOrientation = UIDevice.CurrentDevice.Orientation;
    #region IOrientation
        private UIDeviceOrientation _lastOrientation = UIDeviceOrientation.Unknown;
        private readonly Subject<AppOrientation>  _orientation=new Subject<AppOrientation>();
        public AppOrientation CurrentOrientation
        {
            get
            {
                return
                    (_lastOrientation == UIDeviceOrientation.LandscapeLeft || _lastOrientation == UIDeviceOrientation.LandscapeRight) ? AppOrientation.Landscape :
                    (_lastOrientation == UIDeviceOrientation.Portrait || _lastOrientation == UIDeviceOrientation.PortraitUpsideDown) ? AppOrientation.Portrait : 
                    AppOrientation.Unknown;
            }
        }
        public IObservable<AppOrientation> Orientation { get { return _orientation; } }
        #endregion
