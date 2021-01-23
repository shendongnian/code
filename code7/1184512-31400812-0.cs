    public ActionResult Index()
    {
        List<category> cat = _business.ViewAllcat().ToList();
        List<Books> book = _business.ViewAllBooks().ToList();
        return View(new CatBooks { Cats = cat, Books = book });
    }
    
    public class CatBooks {
        public List<category> Cats { get; set; }
    	public List<Books> Books { get; set; }
    }
