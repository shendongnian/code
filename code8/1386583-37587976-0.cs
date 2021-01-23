     public partial class App : Application
      {
        public App()
        {      
           Activated += (s,e) => 
           {
              App.Current.MainWindow.SetValue(MyApp.MainWindow.IsFocusedProperty, false);
           };
        }   
      }
