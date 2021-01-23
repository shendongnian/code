    public string AddObjectsToJson<T>(string json, List<T> objects)
    {
        List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
        list.Add(objects);
        return JsonConvert.SerializeObject(list);
    }
