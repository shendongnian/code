    [NotifyPropertyChanged]
    public class MainViewModel
    {
        public int RandInt { get; set; }
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
                AsyncRandomNumber = random.Next( 9999 );
                // Raise the events now, because the method TaskStart never ends.
                NotifyPropertyChangedServices.RaiseEventsImmediate( this );
            }
        }
    }
