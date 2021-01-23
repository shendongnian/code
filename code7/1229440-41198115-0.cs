    Application.Current.UnhandledException += (sender, args) =>
    {
        Debug.WriteLine(args.Exception.ToString()); // {"Exception of type 'System.Exception' was thrown."}
        Debug.WriteLine(args.Exception.Message); // "Exception of type 'System.Exception' was thrown."
        Debug.WriteLine(args.Message); // "System.Exception: Exception of type 'System.Exception' was thrown.\r\n   at AppMetrica.Demo.MainPage.<>c.<.ctor>b__0_2(Object sender, RoutedEventArgs args)"
    };
