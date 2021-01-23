    public class SomeCommand: ICommand
    {
        #region Fields
        MainWindow mainWindow;
        #endregion
        #region Constructors and Destructors
        public SomeCommand( MainWindow mw )
        {
            this.mainWindow = mw;
        }
        #endregion
        #region ICommand
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute( object parameter )
        {
            return ( this.mainWindow.listbox1.SelectedItems.Count != 0 
                    && this.mainWindow.listbox2.SelectedItems.Count != 0 );
        }
        public void Execute( object parameter )
        {
            //DO STUFF;
        }
        #endregion
    }
