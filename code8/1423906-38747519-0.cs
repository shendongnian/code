    public class LongLastingWorkViewModel : INotifyPropertyChanged
    {
        public bool Busy 
        {
            // INotifyPropertyChanged property implementation omitted
        }
        public double PercentComplete 
        {
            // INotifyPropertyChanged property implementation omitted
        }
    
        public ICommand PerformWork { get; set; }
    
        public LongLastingWorkViewModel()
        {
            // delegated ICommand implementation omitted--there's TONS of it out there
            PerformWork = new DelegatedCommand(TraverseYo);
        }
    
        private void TraverseYo()
        {
            // we are on the UI thread here
            Busy = true;
            PercentComplete = 0;
            Task.Run(() => {
                // we are on a background thread here
                // this is an example of long lasting work 
                for(int i = 0; i < 10; i++)
                {
                    Thread.Sleep(10 * 1000); // each step takes 10 seconds
    
                    // even though we are on a background thread, bindings
                    // automatically marshal property updates to the UI thread
                    // this is NOT TRUE for INotifyCollectionChanged updates!
                    PercentDone += .1; 
                }
                Busy = false;            
            });
    }
