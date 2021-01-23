    namespace TestItemsControl
    {
        public class TestViewModel
        {
            public ObservableCollection<Entry> Entries=new ObservableCollection<Entry>();
    
            public ICommand UpdateCmd { get; set; }
    
            public TestViewModel()
            {
                this.Entries.Add(new Entry{ Name = "1", LastUpdated = DateTime.Now });
                this.Entries.Add(new Entry { Name = "2", LastUpdated = DateTime.Now });
                this.Entries.Add(new Entry { Name = "3", LastUpdated = DateTime.Now });
            }
        }
    }
