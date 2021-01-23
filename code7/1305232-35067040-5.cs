    public class CustomCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
            MessageBox.Show(parameter.ToString());
        }
    }
