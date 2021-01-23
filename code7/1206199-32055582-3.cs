    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
      GridLength firstWidth;
      GridLength secondWidth;
      public MainPage()
      {
        firstWidth = secondWidth = new GridLength(1, GridUnitType.Star);
        DataContext = this;
        InitializeComponent();
      }
      void RaisePropertyChanged([CallerMemberName] string name = "")
      {
        var handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(name));
      }
      public event PropertyChangedEventHandler PropertyChanged;
    
      public GridLength FirstColumnWidth
      {
        get { return firstWidth; }
        set { firstWidth = value; RaisePropertyChanged(); }
      }
    
      public GridLength SecondColumnWidth
      {
        get { return secondWidth; }
        set { secondWidth = value; RaisePropertyChanged(); }
      }
      private void ToggleColWidth(object sender, RoutedEventArgs e)
      {
        if (FirstColumnWidth.GridUnitType == GridUnitType.Star)
        {
          FirstColumnWidth = new GridLength(0, GridUnitType.Pixel);
          SecondColumnWidth = new GridLength(1, GridUnitType.Star);
        }
        else
        {
          FirstColumnWidth = SecondColumnWidth = new GridLength(1, GridUnitType.Star);
        }
      }
    }
