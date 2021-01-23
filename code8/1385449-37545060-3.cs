    [HttpPost]
    public ActionResult Shuffle(string list)
    {
        var js = new JavaScriptSerializer();
        var deserializedList = (object[])js.DeserializeObject(list);
        return RedirectToAction("Shuffled", new { l = deserializedList });
    }
