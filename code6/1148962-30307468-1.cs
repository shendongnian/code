    public static string SerializeToJson(object instance)
    {
      using (MemoryStream _Stream = new MemoryStream())
      {
        var _Serializer = new DataContractJsonSerializer(instance.GetType());
        _Serializer.WriteObject(_Stream, instance);
        _Stream.Position = 0;
        using (StreamReader _Reader = new StreamReader(_Stream))
        { return _Reader.ReadToEnd(); }
      }
    }
