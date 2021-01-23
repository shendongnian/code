    public class MyViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }
        public MyViewModel()
        {
            this.Categories = new List<Category>();
            this.Books = new List<Book>();
        }
    }
    public ActionResult Index()
    {
        MyViewModel model = new MyViewModel();
        model.Categories = _business.ViewAllcat().ToList();
        model.Books = _business.ViewAllBooks().ToList();
        return View(model);
    }
