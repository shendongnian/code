    public partial class MainWindow : Window
    {
       public ObservableCollection<BitmapImage> MyBitmapSources 
       { 
          get { return (ObservableCollection<BitmapImage>)Application.Current.Resources["MyBitmapSources"]; }
          set { Application.Current.Resources["MyBitmapSources"] = value; } 
       }
