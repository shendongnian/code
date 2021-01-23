    [HttpPost]
    public ActionResult DATACRUD()
    {
        Stream req = Request.InputStream;
        req.Seek(0, System.IO.SeekOrigin.Begin);
        string json = new StreamReader(req).ReadToEnd();
        return Json(new { fromMVC = json });
    }
