    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region members
        protected IUnitOfWork UnitOfWork;
        #endregion
        public BaseViewModel()
        {            
        }
         //basic ViewModelBase
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
    }
