    public class CommandBase<T> : INotifyPropertyChanged
    {
        #region "INotifyPropertyChanged members"
        public event PropertyChangedEventHandler PropertyChanged;
        //This routine is called each time a property value has been set. 
        //This will //cause an event to notify WPF via data-binding that a change has occurred. 
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        private ObservableCollection<T> collection;
        public ObservableCollection<T> Collection
        {
            get
            {
                if (collection == null)
                {
                    Get();
                }
                return collection;
            }
            set { collection = value; OnPropertyChanged("Collection"); }
        }
        private ICommand getCommand;
        private ICommand saveCommand;
        private ICommand removeCommand;
        public ICommand GetCommand
        {
            get
            {
                return getCommand ?? (getCommand = new RelayCommand(Get, CanGet));
            }
        }
        protected virtual bool CanGet()
        {
            return true;
        }
        protected virtual void Get()
        {
            //return true;
        }
        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        return saveCommand ?? (saveCommand = new RelayCommand(param => Save()));
        //    }
        //}
        protected virtual bool CanSave()
        {
            return true;
        }
        //public ICommand DeleteCommand
        //{
        //    get
        //    {
        //        return removeCommand ?? (removeCommand = new RelayCommand(param => Delete()));
        //    }
        //}
        protected virtual bool CanDelete()
        {
            return true;
        }
    }
