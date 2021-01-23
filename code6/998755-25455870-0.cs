    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      info.AddValue("Id", Id);
      if (SomeCondition)
      {
        info.AddValue("FirstName", FirstName);
        info.AddValue("LastName", LastName);
      }
    }
