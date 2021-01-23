    
    public T DeepCopy<T>(object o)
    {
        string json=JsonConvert.SerializeObject(o);
        T newO=JsonConvert.DeserializeObject<T>(json);
        return newO;
    }
