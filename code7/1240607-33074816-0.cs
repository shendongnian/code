    public class NavigationExtension
    {
        public static void Navigate(Type typeOfPage)
        {
            Windows.UI.Xaml.Window window = Windows.UI.Xaml.Window.Current;
            if (window != null)
            {
                Windows.UI.Xaml.Controls.Frame frame = window.Content as Windows.UI.Xaml.Controls.Frame;
                if (frame != null)
                {
                    frame.Navigate(typeOfPage);
                }
            }
        }
    }
