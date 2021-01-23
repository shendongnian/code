        public IJsonData ParseWithJObjectParse(string json, string episodesName, string titleName)
    {
        var obj = JObject.Parse(json);
     
        if (obj == null)
            return null;
     
        var items = obj.GetValue(episodesName).Select(
    e => new JsonItem(((JObject)e).GetValue(titleName).ToString()));
     
        var jsonItems = items.Cast<IJsonItem>().ToArray();
        var result = new JsonData
        {
            Items = jsonItems
        };
     
        return result;
    }
