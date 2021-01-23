    public ActionResult Index()
    {
        byte[] contents = doc.GetBytes(); //?????
        return File(contents, "application/pdf", "test.pdf");
    }
