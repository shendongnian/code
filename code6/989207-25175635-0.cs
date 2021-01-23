    private static VehicleMainViewModel _Instance;
        public static VehicleMainViewModel getInstance
        {
            get
            {
                if(_Instance==null)
                {
                    _Instance = new VehicleMainViewModel();
                }
                return _Instance;
            }
        }
