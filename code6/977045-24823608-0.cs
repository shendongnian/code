    public class RootPage
    {
       public RootPage(INavigationPage navigationPage,
          Func<Action, IDetailPage> detailPageFactory)
       {
          var detailPage = detailPageFactory(myAction);
       }
    }
