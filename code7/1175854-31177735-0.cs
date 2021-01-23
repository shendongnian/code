    public class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            Master = new Menu();
            Detail = new NavigationPage(new detail());
        }
    }
