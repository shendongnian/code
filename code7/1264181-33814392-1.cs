    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            var style = (Style)Application.Current.Resources["defaultPageStyle"];
            Style = style;
        }
    }
