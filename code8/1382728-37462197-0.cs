    public static byte[] ObjectToByteArray(object obj)
    {
        if(obj == null)
            throw new ArgumentNullException($"The parameter {nameof(obj)} can't be null");
    
        var json = JsonConvert.SerializeObject(obj);
    
        var bytes = Encoding.UTF8.GetBytes(json);
    
        return bytes;
    }
