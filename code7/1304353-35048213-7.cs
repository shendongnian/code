    public class MyViewModel : ViewModelBase 
    {
        public MyViewModel(MyCommandHandler commandHandler)
        {
            OneCommand = commandHandler.CreateMyCommand(this);
            OtherCommand = commandHandler.CreateMyOtherCommand(this);
        }
        public ICommand OneCommand { get; private set; } 
        public ICommand OtherCommand { get; private set; } 
    }
