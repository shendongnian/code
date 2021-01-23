    Class Data
    {
      public List  List<category> cat {get;set;}
       public List  List<Books> book {get;set;}
      
    }
     public ActionResult Index()
    {
        Data d=new Data();
        d.cat = _business.ViewAllcat().ToList();
        d.book = _business.ViewAllBooks().ToList();
        return View(d);
    }
