    public partial class MainWindow : Window
    {
       public ObservableCollection<BitmapImage> MyBitmapSources 
       { 
          get { return MySingleton.Instance.MyBitmapSources; }
       }
