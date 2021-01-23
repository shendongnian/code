    public class RegionLocator
    {
        private static RegionLocator instance;
        private static ReverseLookup ReverseLookup;
        private RegionLocator() { }
        public static RegionLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegionLocator();
                    ReverseLookup = new ReverseLookup();
                }
                return instance;
            }
        }
        public Region Lookup(float lat, float lng, RegionType[] types)
        {
            return ReverseLookup.Lookup(lat, lng, types);
        }
        public Region[] Regions()
        {
            return ReverseLookup.Regions;
        }
    }
