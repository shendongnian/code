    public class ViewModel
    {
        public ICommand SaveCommand { get; private set; }
        public ViewModel()
        {
            SaveCommand = new AsyncCompositeCommand(new IAsyncCommand[] 
            {
                command1,
                command2,
                ...
            },
            param => Console.WriteLine("Done"));
        }
    }
