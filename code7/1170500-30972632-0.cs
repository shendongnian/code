    public void View(string newView) 
    {
         NavigationService nav = NavigationService.GetNavigationService(this);
         nav.Navigate(new Uri(View ,UriKind.RelativeOrAbsolute));
    }
