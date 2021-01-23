    public static IRegionManager NavigateView(this IRegionManager regionManager, string regionName, string view, NavigationParameters parameters = null)
                    {
                        var navigationUri = new Uri(view, UriKind.Relative);
    
    regionManager.RequestNavigate(regionName, navigationUri, parameters);
    
     return regionManager;
        }
