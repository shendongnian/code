    public class PageBase : ContentPage
    {        
        public void DisplayAlert(string message,string title, string button)
        {
             Device.BeginInvokeOnMainThread (() => {
                  DisplayAlert(message, title, button);
                  });
        }
    }
