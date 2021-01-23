    [HttpPost]
    public JsonResult DoStuff()
    {
        var MyDictionary = new Dictionary<string, string>();
        MyDictionary.Add("Foo", "TTTDic");
        MyDictionary.Add("Bar", "Scoo");
        return Json(MyDictionary);
    }
