	public class RelayCommand : ICommand 
	{
	     public RelayCommand(Action<object> execute)
           : this(execute, null)
       {
       }
		
		public bool CanExecute(object parameter)
        {
        }
        public void Execute(object parameter)
        {
        }
        public event EventHandler CanExecuteChanged;
	} 
	
