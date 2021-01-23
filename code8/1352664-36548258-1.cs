    public class DelegateCommand : ICommand
    {
        #region Data Members
        private Action<object> execute;
        private Predicate<object> canExecute;
        private event EventHandler CanExecuteChangedInternal;
        #endregion
        #region Ctor
        public DelegateCommand(Action<object> execute)
           : this(execute, DefaultCanExecute)
        {
        }
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
           if (execute == null)
           {
               throw new ArgumentNullException("execute");
           }
           if (canExecute == null)
           {
               throw new ArgumentNullException("canExecute");
           }
           this.execute = execute;
           this.canExecute = canExecute;
        }
        #endregion
        #region Properties
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }
        #endregion
        #region Public Methods
        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }
        #endregion
        #region Private Methods
        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
        #endregion
    }
	
