    public T Read()
    {
         return JsonConvert.DeserializeObject<T>(File.ReadAllText(_fileName));
    }
    public void Write(T model)
    {
         File.WriteAllText(_fileName, JsonConvert.SerializeObject(model));
    }
