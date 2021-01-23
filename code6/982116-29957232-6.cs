_lastOrientation = this.Resources.Configuration.Orientation;
 
     #region IOrientation
            private Android.Content.Res.Orientation _lastOrientation;
            private readonly Subject<AppOrientation> _orientation = new Subject<AppOrientation>();
            public AppOrientation CurrentOrientation
            {
                get
                {
                    return _lastOrientation == Android.Content.Res.Orientation.Portrait ? AppOrientation.Portrait :
                        _lastOrientation == Android.Content.Res.Orientation.Landscape ? AppOrientation.Landscape : 
                        AppOrientation.Unknown;
                }
            }
        public IObservable<AppOrientation> Orientation { get { return _orientation; } }
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (newConfig.Orientation == this._lastOrientation)  return; 
            this._lastOrientation = newConfig.Orientation;
            this._orientation.OnNext(this.CurrentOrientation);
        }
        #endregion
