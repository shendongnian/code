    class YourViewModel:INotifyPropertyChanged
    {
      
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        //method to fire the property changed event ...
        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        //To raise the changes in property ...
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }
        #endregion
    }
