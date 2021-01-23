    public class MyViewModel
    {
        public DataTable WatchersGrid { get; set; }
        public MyViewModel()
        {
            WatchersGrid = new MyDataTable();
        }
    }
