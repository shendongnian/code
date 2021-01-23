    public class MainWindowViewModel
    {
        public OpenWindowCommand OpenWindowCommand { get; private set; }
        public MainWindowViewModel()
        {
            OpenWindowCommand = new OpenWindowCommand();
        }
        ...
    }
