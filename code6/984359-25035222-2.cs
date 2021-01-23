    public ActionResult Index(FotoModel model, HttpPostedFileBase file)
    {
      if (file != null)
            {
                int byteCount = file.ContentLength;  // <---Your file Size or Length
                .............
                .............
            }
    }
