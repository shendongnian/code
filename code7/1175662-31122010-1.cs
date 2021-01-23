    var rootObject = JsonConvert.DeserializeObject<MyData.RootObject>(Data);
    List<string> list = new List<string>();
    foreach (var record in rootObject.rows)
    {
        foreach (var nestedRecord in record.f)
        {
            list.Add(nestedRecord.v);         
        }
    }
    return View(list);
