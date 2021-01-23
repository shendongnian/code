    public async Task<ActionResult> Index()
    {
        foreach (string upload in Request.Files)
        {
            var userId = User.Identity.GetUserId();
            string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
            Request.Files[upload].SaveAs(Path.Combine(path, userId + ".jpg"));
        }
        return View();
    }
