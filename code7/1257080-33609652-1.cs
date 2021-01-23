    public class ViewModel
    {
        public ViewModel()
        {
            this.Signals = new ObservableCollection<Signal>();
            this.Signals.Add(new Signal() { LastValue = 12432.33, SignalName = "First Signal"} );
            this.Signals.Add(new Signal() { LastValue = 2.123, SignalName = "Second Signal"});
        }
    
        public ObservableCollection<Signal> Signals { get; set; }
    }
