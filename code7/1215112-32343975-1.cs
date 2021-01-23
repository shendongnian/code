    [HttpGet]
    public ActionResult Index(int? paging)
    {
      var pageList = new int[]{ 1, 5, 10 };
      StudentVM model = new StudentVM()
      {
        Paging = paging ?? 5,
        PageList = new SelectList(pageList),
        Students = // your query to return the students
      };
      return View(model );
    }
