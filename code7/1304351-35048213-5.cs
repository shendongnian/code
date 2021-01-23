    public class MyViewModelCommandHandler
    {
        private readonly IMyRepository myRepository;
        public MyViewModelCommandHandler(/* pass dependencies here*/)
        {
            // assign and guard dependencies
            MyCommand = new RelayCommand(MyCommand, CanExecuteMyCommand);
            MyOtherCommand = new RelayCommand(MyOtherCommand, CanExecuteMyOtherCommand);
        }
        public ICommand MyCommand { get; protected set; } 
        public ICommand MyOtherCommand { get; protected set; } 
        private void MyCommand() 
        {
            // do something
        }
        private void CanExecuteMyCommand() 
        {
            // validate
        }
        private void MyOtherCommand() 
        {
            // do something else
        }
        private void CanExecuteMyOtherCommand() 
        {
            // validate
        }
    }
