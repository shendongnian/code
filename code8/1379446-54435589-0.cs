    public class ListItem
    {
        public string Name { get; set; }
    }
    public class SampleData
    {
        //Parameterless constructor needed!
        public SampleData()
        {
            ListItems = new ObservableCollection<ListItem>();
            ListItems.Add(new ListItem { Name = "foo" });
            ListItems.Add(new ListItem { Name = "bar" });
        }
        public ObservableCollection<ListItem> ListItems { get; set; }
    }
