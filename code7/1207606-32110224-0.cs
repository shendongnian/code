    public class RelayCommand : ICommand, INotifyPropertyChanged
    {
        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseCanExecuteChanged()
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, "CanExecute");
            }
        }
        #endregion
