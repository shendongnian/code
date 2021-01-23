    Uri viewUpper = new Uri("ModuleItemsUpper", UriKind.Relative);
    Uri viewBottom = new Uri("ModuleItemsBottom", UriKind.Relative);
    regionManager.RequestNavigate(RegionNames.TheUpperRegion, viewUpper);
    regionManager.RequestNavigate(RegionNames.TheBottomRegion, viewBottom);
    var loginView = regionManager.Regions[RegionNames.TheWholeRegion].Views.ElementAt(0);
    regionManager.Regions[RegionNames.TheWholeRegion].Remove(loginView);
