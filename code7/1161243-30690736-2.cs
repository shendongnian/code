    public class TestCommand : ICommand
    {
        public ViewModel _vm { get; set; }
        public TestCommand(ViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _vm.FeedbackPanel(parameter.ToString());
        }
    }
