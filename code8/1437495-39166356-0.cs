    public ViewResult Index(int? page)
    {
       int pageSize = 100;
       int pageNumber = (page ?? 1);
       return View(db.TestUploadData2.ToPagedList(pageNumber, pageSize));
    }
