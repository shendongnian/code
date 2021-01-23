        var window1 = new Window1();
        window1.ViewModel.Parameter = "Hello world";
        public class Window1{
           ...
           public Window1ViewModel { get {return (Window1ViewModel)DataContext;}}
        }
    datacontext should be set in ctor or in XAML.
