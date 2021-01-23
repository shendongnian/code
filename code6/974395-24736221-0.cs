    public static void SaveTypes(IEnumerable<Type> types, string filename)
    {
        using (var fs = File.Open(filename, FileMode.OpenOrCreate)
            new XmlSerializer(typeof(string[]))
                .Serialize(fs, types.Select(t => t.FullName).ToArray())
    }
    pubic static IEnumerable<Type> LoadTypes(string filename)
    {
         using (var fs = File.Open(filename, FileMode.Open)
         {
             var typeNames = (string[])
                 new XmlSerializer(typeof(string[]))
                .Deserialize(fs);
              return typeNames.Select(t => Type.Load(t));
         }
    }
