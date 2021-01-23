    public ActionResult Create()
    {
      List<Book> model = new List<Book>();
      for(int i = 0; i < 10;i++)
      {
        model.Add(new Book());
      }
      return View(model);
    }
