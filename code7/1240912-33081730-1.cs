    public string AddObjectsToJson<T>(string json, List<T> objects)
    {
        List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
        list.AddRange(objects);
        return JsonConvert.SerializeObject(list);
    }
