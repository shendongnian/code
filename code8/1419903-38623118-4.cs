    public static byte[] Serialize(object obj)
    {
      var binaryFormatter = new BinaryFormatter();
      var ms = new MemoryStream();
      binaryFormatter.Serialize(ms, obj);
      return ms.ToArray();
    }
