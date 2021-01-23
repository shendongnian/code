    public ActionResult Index()
        {
            List<category> cat = _business.ViewAllcat().ToList();
            List<Books> book = _business.ViewAllBooks().ToList();
            return View(new MyViewModel() { Cats = cat, Books = book);
        }
