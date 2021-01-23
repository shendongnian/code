    public class MagnifyMinimiseCommand : ICommand
    {
        public MagnifyMinimiseCommand(MagnifyMinimise  viewModel)
        {
            this.ViewModel = viewModel;
        }
    
        protected MagnifyMinimise ViewModel { get; }
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public void Execute(object parameter)
        {
            this.ViewModel.Stretch = "...";
        }
    }
