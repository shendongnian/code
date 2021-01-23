    using (SPSite spSite = new SPSite(siteId))
    {
        using (SPWeb web = spSite.OpenWeb(selectedWeb.Id))
        {
            foreach (var spfeature in SPFarm.Local.FeatureDefinitions)
            {
                if (spfeature.Scope.Equals(SPFeatureScope.Web) && !spfeature.Hidden)
                {
                    var feature = new Feature();
                    feature.Name = spfeature.DisplayName;
                    feature.Id = spfeature.Id;
                    feature.IsActive = web.Features[spfeature.Id] != null;
                    result.Add(feature);
                }                            
            }
        }
    }
