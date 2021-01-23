    [HttpGet]
    public ActionResult Upload() {      
        List<string> blobs = new List<string>();
        // add URI strings to list ...
        return View(blobs, "Upload");
    }
