    var selectedCheckBoxItems = from key in Request.Form.AllKeys
                                where key.Contains(cblAnimalType.UniqueID)
                                select new { Value = Request.Form.Get(key), Key = key };
    foreach (var item in selectedCheckBoxItems)
    {
        var val = item.Value;
        string indexToken = item.Key.Replace(cblAnimalType.UniqueID, "");
        int index = int.Parse(Regex.Replace(indexToken, @"[^\d]", ""));
        ...
    }
