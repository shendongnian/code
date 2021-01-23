        private Dictionary<Point, string> _Locations;
        public List<KeyValuePair<Point, string>> SerializedLocations
        {
            get { return _Locations.ToList(); }
            set { _Locations= value.ToDictionary(x => x.Key, x => x.Value); }
        }
