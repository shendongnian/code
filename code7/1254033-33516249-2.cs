    public class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private void OnNotifyPropertyChange([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
