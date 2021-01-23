         if (RegionTypes.Any((x) => x.RegionDesc.ToUpper().Equals("ALL REGIONS") && x.IsChecked))
            {
                foreach (var region in tempRegions.Where((x) => !x.RegionDesc.ToUpper().Equals("ALL REGIONS")))
                    region.IsChecked = true;
        }
            RegionTypes = new ObservableCollection<SearchRegion>();
            RegionTypes = tempRegions;
