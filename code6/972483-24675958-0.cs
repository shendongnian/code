        string json = JsonConvert.SerializeObject(dic.ToList(), Formatting.Indented, new JsonSerializerSettings
      {
          TypeNameHandling = TypeNameHandling.None,
          TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
      });
