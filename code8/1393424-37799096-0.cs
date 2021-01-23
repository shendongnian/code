    public async Task<ActionResult> Index()
    {
        var result = await GetIdAsync();
        ViewBag.result = result.Data;
        return View();
    }
    public async Task<JsonResult> GetIdAsync()
    {
        var result = "";
        var url = "http://APIURL/GetID";
        using (WebClient client = new WebClient())
        {
            // Note the API change here?
            result = await client.DownloadStringAsync(url);
        }
        return Json(result, JsonRequestBehavior.AllowGet);
    }
