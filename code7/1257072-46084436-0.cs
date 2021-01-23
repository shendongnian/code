    JArray jsonResponse = JArray.Parse(goldString);
    
    foreach (var item in jsonResponse)
    {
        foreach (var rItem in jRaces)
        {
            string rItemKey = rItem.Key;
            JObject rItemValueJson = (JObject)rItem.Value;
            Races rowsResult = item.Value<JObject>("races").ToObject<Races>();
        }
    }
