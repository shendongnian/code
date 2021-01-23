    // WinRT
    // var frame = (Frame)Windows.UI.Xaml.Window.Current.Content;
    // var page = (MainPage)frame.Content;
    // Silverlight
    var page = (MainPage)Application.Current.RootVisual;
    var viewmodel = (MyViewModel)page.DataContext;
    viewmodel.StatusText = "new text";
