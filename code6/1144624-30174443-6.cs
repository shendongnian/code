    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       public MainWindow()
       {
          InitializeComponent();
          DataContext = this;
       }
    
       private ImageSource _myImageSource;
    
       public ImageSource MyImageSource
       {
          get { return _myImageSource; }
          set
          {
              _myImageSource = value;
              OnPropertyChanged("MyImageSource");
          }
       }
       private void ImageButton_Click(object sender, RoutedEventArgs e)
       {
           this.MyImageSource = new BitmapImage(...); //you change source of the Image
       }
      
       public event PropertyChangedEventHandler PropertyChanged;
    
       private void OnPropertyChanged(string propertyName)
       {
          var handler = PropertyChanged;
          if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
       }    
    }
