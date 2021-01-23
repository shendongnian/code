    public class CarViewModel : INotifyPropertyChanged
    {
          public MainViewModel { get; set; }
          public bool IsSelected { get { return this == MainViewModel.CurrentlySelectedCar; } }
  
          // Call RaisePropertyChanged("IsSelected") whenever
          // CurrentlySelectedCar is changed
          public void RaisePropertyChanged(string propertyName) 
          {
              if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
          }
    }
