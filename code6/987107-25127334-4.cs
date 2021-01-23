    [HttpPost]
    public void SaveField(string globalList, string fieldName)
    {
        var serializer = new JavaScriptSerializer(); //use any serializer you want
        var list = serializer.Deserialize<List<Point>>(globalList);
    }
