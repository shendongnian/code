    public class TestItem
    {
        //Properties
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        // Constructor
        public TestItem(int id, int parentId, string title, string description, string url)
        {
            Id = id;
            ParentId = parentId;
            Title = title;
            Description = description;
            Url = url;
        }
    }
    public class TestItemsRepository
    {
        private List<TestItem> data;
        private TestItemsRepository instance;
        private TestItemsRepository()
        {
            //Populate data
            data = new List<TestItem>
            {
                new TestItem
                {
                    Id = 0,
                    ParentId = 0,
                    Title = "",
                    Description = "",
                    Url = ""
                },
            };
        }
        public static IEnumerable<TestItem> GetTestItems()
        {
            if (instance==null)
            {
                 instance = new TestItemsRepository();
            }
            return instance.data;
        }
    }
