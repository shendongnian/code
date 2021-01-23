    public class MainLink : Button
    {
        public MainLink(string name,string page)
        {
            Text = name;
            Command = new Command(o => {
                Type pageType = Type.GetType(page);
                App.MasterDetailPage.Detail = new NavigationPage(Activator.CreateInstance(pageType) as Page);
                App.MasterDetailPage.IsPresented = false;
            });
        }
    }
