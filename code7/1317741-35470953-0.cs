    public static List<JObject> normalizeKeys(List<JObject> jObjList)
    {
        // create a new list for return and copy over the existing items
        var jObjReturnList = new List<JObject>(jObjList.Count);
        jObjList.ForEach(jobj =>
        {
            var jObjNew = new JObject();
            foreach (var kvp in jobj)
            {
                jObjNew.Add(kvp.Key.ToUpper(), kvp.Value);
            }
    
            jObjReturnList.Add(jObjNew);
        });
    
        return jObjReturnList;
    }
