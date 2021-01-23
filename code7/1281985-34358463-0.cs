    class CancelCommand : ICommand
        {
            private NewTruckViewModel newTruck;
            public CancelCommand(NewTruckViewModel vm)
            {
                newTruck = vm;
            }
            public event EventHandler CanExecuteChanged;
    
            public bool CanExecute(object parameter)
            {
                return true;
            }
    
            public void Execute(object parameter)
            {
                newTruck.Cancel();
            }
        }
