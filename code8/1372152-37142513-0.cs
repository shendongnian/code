    public class App: Application
    {
        public static NavigationPage MyNavigationPage;
        public App()
        {
            MyNavigationPage = new NavigationPage();
            MainPage = MyNavigation;
            MyNavigation.PushAsync(new Page_Countries, true);
        }
    }
