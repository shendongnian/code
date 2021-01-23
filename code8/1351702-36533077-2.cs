         public class ViewModel:INotifyPropertyChanged{
         //Example for a valid INotifyPropertyChanged member
         private bool _visibility;
         public bool Visibility
        {
            get { return _visibility; }
            set { _visibility = value;  OnPropertyChanged("Visibility");}
        }
         public event PropertyChangedEventHandler PropertyChanged;
         private void OnPropertyChanged(string propertyName){
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
        }
         
