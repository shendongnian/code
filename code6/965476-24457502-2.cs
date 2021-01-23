    public class NotifyPropertyChangeableBase: INotifyPropertyChanged // Usually I name it somewhat like 'ViewModelBase' in my projects, but your actual class is the control, so it is not the most appropriate name
    {
        protected void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
