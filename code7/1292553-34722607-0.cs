    public class ModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors
        {
            get
            {
                return GetErrors(null).OfType<object>().Any();
            }
        }
        public virtual void ForceValidation()
        {
            OnPropertyChanged(null);
        }
        public virtual IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            return Enumerable.Empty<object>();
        }
        protected void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            OnErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        protected virtual void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var handler = ErrorsChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
