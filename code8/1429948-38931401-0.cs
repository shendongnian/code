    public class ExpiryDictionarty
    {
        Timer timer; //will hanlde the expiry
        ConcurrentDictionary<string, string> state; //will be used to save the last event
    
        public ExpiryDictionarty(int milisec)
        {
            state = new ConcurrentDictionary<string, string>();
            timer = new Timer(milisec);
            timer.Elapsed += new ElapsedEventHandler(Elapsed_Event);
            timer.Start();
        }
    
        private void Elapsed_Event(object sender, ElapsedEventArgs e)
        {
            foreach (var key in state.Keys)
            {
                //fire the calculation for each event in the dictionary
            }
            state.Clear();
        }
    
        public void Add(string key, string value)
        {
            state.AddOrUpdate(key, value);
        }
    }
