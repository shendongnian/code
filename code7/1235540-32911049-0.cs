    [HttpPost]
    [ValidateInput(false)]
    public ActionResult UpdateContent(string elementId, string newContent)
    {
        System.Diagnostics.Debug.WriteLine("!" + elementId);
        System.Diagnostics.Debug.WriteLine("!" + newContent);
        string _result = "true";
        return Json(new { result = _result });
    }
