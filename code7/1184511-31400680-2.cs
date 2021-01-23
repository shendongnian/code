    Class Data
    {
      public List<category> cat {get;set;}
       public List<Books> book {get;set;}
       public Data()
       {
          this.cat = new List<category>();
          this.book = new List<Books>();
       }
      
    }
     public ActionResult Index()
    {
        Data d=new Data();
        d.cat = _business.ViewAllcat().ToList();
        d.book = _business.ViewAllBooks().ToList();
        return View(d);
    }
