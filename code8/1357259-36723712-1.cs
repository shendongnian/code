    [NotifyPropertyChanged]
    public class MainViewModel
    {
        public int RandInt { get; set; }
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        public MainViewModel()
        {
            RandInt = 10;
            new Task(TaskStart).Start();
        }
        private void TaskStart()
        {
            Random rand = new Random();
            while (true)
            {
                dispatcher.InvokeAsync( () => AsyncRandomNumber = random.Next( 9999 ) );
            }
        }
    }
