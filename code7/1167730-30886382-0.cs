    public static T DeepCopy<T>(T objectToCopy)
    {
     using (var memStr = new MemoryStream())
     {
       var binFormatter = new BinaryFormatter();
       binFormatter.Serialize(memStr, objectToCopy);
       memStr.Position = 0;
       return (T) formatter.Deserialize(memStr);
     }
    }
