    public class MyViewModel
    {
        public Computer Computer { get; set; }
        public IEnumerable<string> SelectedUsers { get; set; }
    }
    public ActionResult Create(MyViewModel viewModel)
    {
        ...
    }
