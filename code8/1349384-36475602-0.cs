    partial void vwFamilyProcessDatas_Updating(vwFamilyProcessData entity)
        {
            if(entity.Details.EntityState.ToString() == "Modified")
            {
                var AutoAddMissingListing = entity.AutoAddMissingListing;
                var AutoAddOddLots = entity.AutoAddOddLots;
                var DefaultFilterValue = entity.DefaultFilterValue;
                var ExcludeZeroNumberOfUnits = entity.ExcludeZeroNumberOfUnits;
                var IgnoreForPricing = entity.IgnoreForPricing;
                var LimitEndDate = entity.LimitEndDate;
                var OffsetFromMaxAsAtDate = entity.OffsetFromMaxAsAtDate;
                var PrefilterConstituents = entity.PrefilterConstituents;
                var TimeDataExpires = entity.TimeDataExpires;
                tblFamily objFamily = tblFamilies.Where(f => f.FamilyID == entity.FamilyID).Single();
                objFamily.AutoAddMissingListing = AutoAddMissingListing;
                objFamily.AutoAddOddLots = AutoAddOddLots;
                objFamily.DefaultFilterValue = DefaultFilterValue;
                objFamily.ExcludeZeroNumberOfUnits = ExcludeZeroNumberOfUnits;
                objFamily.IgnoreForPricing = IgnoreForPricing;
                objFamily.LimitEndDate = LimitEndDate;
                objFamily.OffsetFromMaxAsAtDate = OffsetFromMaxAsAtDate;
                objFamily.PrefilterConstituents = PrefilterConstituents;
                objFamily.TimeDataExpires = TimeSpan.Parse(TimeDataExpires);
                entity.Details.DiscardChanges();
            }}
