     public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                ValidateAsync();
            }
            #endregion
    }
