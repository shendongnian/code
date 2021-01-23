    [HttpPost]
    public ActionResult Create(IEnumerable<HttpPostedFileBase> files)
    {
        if (files != null && files.Any())
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    //do something
                }
            }
        }
    }
