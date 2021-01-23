    public static void LoadLayout(Type pageType)
    {
        // just ensure that the window is active
        RootFrame = new _Layout();
        RootFrame.ContentFrame.Navigate(pageType, null);
        RootFrame.ContentFrame.Navigated += ContentFrame_Navigated;
        ContentFrame_Navigated(null, null);
        Window.Current.Content = RootFrame;
    }
