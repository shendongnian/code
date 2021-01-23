    public class ViewModelClass : INotifyPropertyChanged
    {
        private CScheduler scheduler;
        //Add this:
        public static ViewModelClass Instance {get; set;} //NEW
        public ViewModelClass()
        {
            scheduler = new Scheduler();
        }
        public string NextSynchronization
        {
            get
            {
                return scheduler.GetNextSync();
            }
        }
    }
