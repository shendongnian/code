    public T Read()
    {
         return JsonConvert.DeserializeObject<T>(File.ReadAllText(_filePath));
    }
    public void Write(T model)
    {
         File.WriteAllText(_filePath, JsonConvert.SerializeObject(model));
    }
