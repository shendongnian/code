    public class NavigationExtensions
    {
    public static void Initialize<T>(List<NavMenuItem> list, NavigationFailedEventHandler OnNavigationFailed, LaunchActivatedEventArgs e)
        {
            AppShell shell = Window.Current.Content as AppShell;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (shell == null)
            {
                // Create a AppShell to act as the navigation context and navigate to the first page
                shell = new AppShell();
                shell.NavigationList = list;
                try
                {
                    shell.CurrentItem = list.First(i => i.DestPage == typeof(T));
                }
                catch
                {
                }
                // Set the default language
                shell.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
                shell.AppFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
            }
            // Place our app shell in the current Window
            Window.Current.Content = shell;
            if (shell.AppFrame.Content == null)
            {
                // When the navigation stack isn't restored, navigate to the first page
                // suppressing the initial entrance animation.
                shell.AppFrame.Navigate(typeof(T), e.Arguments, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
