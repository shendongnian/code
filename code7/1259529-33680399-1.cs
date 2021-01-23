    class UIControl : MainWindow
    {
        public static void ChangeButtonName(string text)
        {
            App.Current.Dispatcher.Invoke(delegate {
                xamlStaticButton.Content = text;
            });
        }
    }
