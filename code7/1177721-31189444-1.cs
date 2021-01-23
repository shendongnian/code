    public class Dummy
        {
            public ObservableCollection<string> TestFailItems { get; set; }
    
            public Dummy()
            {
                TestFailItems = new ObservableCollection<string>(new List<string> { "a", "b" });
            }
        }
        public class Model
        {
            public Dummy SelectedComparisonResult { get; set; }
    
            public Model()
            {
                SelectedComparisonResult = new Dummy();
            }
        }
