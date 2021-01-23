    public class StateVM
        {        
            public List<CountryStates> Collection { get; set; }
            public StateVM() { Collection = new List<CountryStates>(); }
        }
    public class CountryStates
        {
            public string SelectedState { get; set; } /* SelectedItem will arrive here */
            public string Name { get; set; }
            public List<string> States { get; set; }
        }
