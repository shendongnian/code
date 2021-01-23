        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
            if (_map == null)
            {
                _map = map;
            }
        }
