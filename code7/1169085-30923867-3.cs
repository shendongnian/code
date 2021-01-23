    public class CheckedCommand : ICommand
    {
        private ViewModel _vm = null;
        public CheckedCommand(ViewModel _viewModel)
        {
            _vm = _viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _vm.CheckedHandler();
        }
    }
