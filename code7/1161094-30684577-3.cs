        public class ChangeCommand : ICommand
    {
        public ViewModel _vm = null;
        public ChangeCommand(ViewModel vm)
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
           _vm.VehicleSelected = _vm.vehicles.First( name => name.Name.Equals(parameter.ToString()));
        }
    }
