    public class Model : INotifyPropertyChanged
    {
        public event EventHandler PropertyChanged; // event from INotifyPropertyChanged
        protected void RaisePropertyChanged(string propertyName)
        {
            var local = PropertyChanged;
            if (local != null)
            {
                local.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void ToggleMode()
        {
            // ... your code ...
            RaisePropertyChanged("ModelLabelText");
        }
    }
