    public class WinRtNavigationService : INavigationService 
    {
        public void Navigate(string page, object parameter) 
        {
            Type pageType = Type.GetType(string.Format("YourCompany.YourApp.ViewModels.{0}", page));
            ((Frame)Window.Current.Content).Navigate(pageType, parameter);
        }
    }
