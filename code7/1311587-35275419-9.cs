    static void Main(string[] args)
    {
      var dict = new XmlDictionary();
      var session = new XmlBinaryWriterSession();
      var key = 0;
      session.TryAdd(dict.Add("myLongRoot"), out key);
      session.TryAdd(dict.Add("myLongChild"), out key);
      session.TryAdd(dict.Add("myLongText"), out key);
      var root = new myLongRoot { Items = new List<myLongChild>() };
      root.Items.Add(new myLongChild { myLongText = 24 });
      root.Items.Add(new myLongChild { myLongText = 25 });
      root.Items.Add(new myLongChild { myLongText = 27 });
      string foo = null;
      using (var stream = new MemoryStream())
      {
        using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream, dict, session))
        {
          var dcs = new DataContractSerializer(typeof(myLongRoot));
          dcs.WriteObject(writer, root);
        }
        foo = Encoding.UTF8.GetString(stream.ToArray());
        // breakpoint here to check the foo variable :) - no elements here ;)
      }
    }
    
