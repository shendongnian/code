    public class ChangeWidthCommand : ICommand
    {
        ViewModel vm { get; set; }
        public ChangeWidthCommand(ViewModel _vm)
        {
            vm = _vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            vm.CanvasWidth += 10;
        }
    }
