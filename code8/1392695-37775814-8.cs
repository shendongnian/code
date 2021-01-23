    public class MainLink : Button
    {
        public MainLink(string name, Type pageType)
        {
            Text = name;
            Command = new Command(o => {
                App.MasterDetailPage.Detail = new NavigationPage(Activator.CreateInstance(pageType) as Page);
                App.MasterDetailPage.IsPresented = false;
            });
        }
    }
