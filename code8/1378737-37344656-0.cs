    @Html.BeginForm("UploadFile", "Controller", new { type = "form/multipart" })
    {
        <input type="file" name="file" />
        <button type="submit" value="Upload" />
    }
    @Html.BeginForm("Index", "Controller")
    {
        <input type="checkbox" name="Album" value="No. Dolls!" />
        <input type="checkbox" name="Album" value="O.B.I." />
        <button type="submit" value="Upload" />
    }
    [HttpPost]
    public ActionResult UploadFile(HttpPostedFileBase file) 
    { 
        // here you are working with uploaded file
        return View("Index"); 
    }
    [HttpPost]
    public ActionResult Index(List<Album> list)
    {
        // here you are working with checkbox list items
        return View();
    }
