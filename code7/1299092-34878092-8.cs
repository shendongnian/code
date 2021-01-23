    public class MyCustomCommand : ICommand
    {
        private TabItem Target { get; set; }
    
        public MyCustomCommand (TabItem item)
        {
            Target = item;
        }
    
        public bool CanExecute(object parameter)
        {
            return true;;
        }
    
        public void Execute(object parameter)
        {
            //Do something with Target
        }
        ...
    }
