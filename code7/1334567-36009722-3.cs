     public class BindableObject : INotifyPropertyChanged
        {
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
    
        }
