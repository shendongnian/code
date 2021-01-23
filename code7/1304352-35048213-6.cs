    public class MyViewModel : ViewModelBase 
    {
        public MyViewModel()
        {
            var commandHandler = new MyCommandHandler(this);
            OneCommand = commandHandler.MyCommand;
            OtherCommand = commandHandler.MyOtherCommand;
        }
        public ICommand OneCommand { get; private set; } 
        public ICommand OtherCommand { get; private set; } 
    }
