             private ObservableCollection<SearchRegion> _regionTypes;
        public ObservableCollection<SearchRegion> RegionTypes
        {
            get { return _regionTypes; }
            set
            {
                _regionTypes = value;
                RaisePropertyChanged();
            }
        }
        RegionTypes = new ObservableCollection<SearchRegion>
            {   new SearchRegion {RegionDesc = "All Regions"},
                new SearchRegion {RegionDesc = "Region 4", Region="4"},
                new SearchRegion {RegionDesc = "Region 1", Region="1"},
                new SearchRegion {RegionDesc = "Region 5", Region="5"},
                new SearchRegion {RegionDesc = "Region 2", Region="2"},
                new SearchRegion {RegionDesc = "Region 6", Region="6"},
                new SearchRegion {RegionDesc = "Region 3", Region="3"}
            };
