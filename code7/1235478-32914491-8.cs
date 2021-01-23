    namespace TestPopWpfWindow
    {
        
        public class ViewModelBase : INotifyPropertyChanged
        {
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
    
        }
    }
