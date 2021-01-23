    public class Viewmodel
    {
        private ObservableCollection<Entry> collection = new ObservableCollection<Entry>()
        {
            new Entry() { Title = "Entry 1" },
            new Entry() { Title = "Entry 2" },
            new Entry() { Title = "Entry 3" }
        };
        public ObservableCollection<Entry> Collection
        {
            get { return collection; }
            set { collection = value; }
        }
    }
