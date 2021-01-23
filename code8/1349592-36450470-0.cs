    protected ProjectHttpClientEx(SerializationInfo info, StreamingContext context)
    {
      member = info.GetBoolean("somedata"); // or empty
    }
    
    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("somedata", true);
    }
