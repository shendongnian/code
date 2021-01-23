    public class MainViewModel
    {
        public List<ListItemViewModel> items { get; set; }
        public MainViewModel()
        {
            List<ListItemViewModel> things = new List<ListItemViewModel>();
            List<string> temp = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                temp.Add(i + "");
                things.Add(new ListItemViewModel()
                {
                    text = "item"+i,
                    strings = temp.ToList<string>()
                });
            }
            items = things;
        }
    }
    public class ListItemViewModel
    {
        public String text { get; set; }
        public List<string> strings { get; set; }
    }
