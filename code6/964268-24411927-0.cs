    keys[3] = {"id", "name", "comment"}
    values[3] = {1, "Ackerman", "superuser"}
    dynamic item = new ExpandoObject();
    var dItem = item as IDictionary<String, object>;
    for(int buc = 0; buc < keys.Length; buc++)
        dItem.Add(keys[buc], values[buc]);
