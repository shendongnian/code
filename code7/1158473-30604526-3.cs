    public class ItemClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
            
        public void Execute(object parameter)
        {
            // parameter will be the item clicked
        }
    }
