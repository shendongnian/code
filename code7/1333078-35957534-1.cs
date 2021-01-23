    public async Task<ActionResult> Upload()
    {
        var files = new HttpPostedFileBase[Request.Files.Count];
        Request.Files.CopyTo(files, 0);
    	var tasks = files.Select(f=>new Uploader().UploadFile(f));
        await Task.WhenAll(tasks);
        return Json(tasks.Where(v=>v.Status == TaskStatus.RanToCompletion ).Select(v=>v.Result).ToList());
    }
