    // order matters - add new items only at the bottom
    static readonly string[] s_Terms = new string[]
    {
        "myLongRoot", "myLongChild", "myLongText", 
        "http://www.w3.org/2001/XMLSchema-instance", "Items"
    };
    public class CustomXmlBinaryWriterSession : XmlBinaryWriterSession
    {
      private bool m_Lock;
      public void Lock() { m_Lock = true; }
      public override bool TryAdd(XmlDictionaryString value, out int key)
      {
        if (m_Lock)
        {
          key = -1;
          return false;
        }
        return base.TryAdd(value, out key);
      }
    }
    static void InitializeWriter(out XmlDictionary dict, out XmlBinaryWriterSession session)
    {
      dict = new XmlDictionary();
      var result = new CustomXmlBinaryWriterSession();
      var key = 0;
      foreach(var term in s_Terms)
      {
        result.TryAdd(dict.Add(term), out key);
      }
      result.Lock();
      session = result;
    }
    static void InitializeReader(out XmlDictionary dict, out XmlBinaryReaderSession session)
    {
      dict = new XmlDictionary();
      var result = new XmlBinaryReaderSession();
      for (var i = 0; i < s_Terms.Length; i++)
      {
        result.Add(i, s_Terms[i]);
      }
      session = result;
    }
    static void Main(string[] args)
    {
      XmlDictionary dict;
      XmlBinaryWriterSession session;
      InitializeWriter(out dict, out session);
      var root = new myLongRoot { Items = new List<myLongChild>() };
      root.Items.Add(new myLongChild { myLongText = 24 });
      root.Items.Add(new myLongChild { myLongText = 25 });
      root.Items.Add(new myLongChild { myLongText = 27 });
    
      byte[] buffer;
      using (var stream = new MemoryStream())
      {
        using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream, dict, session))
        {
          var dcs = new DataContractSerializer(typeof(myLongRoot));
          dcs.WriteObject(writer, root);
        }
        buffer = stream.ToArray();
      }
      XmlBinaryReaderSession readerSession;
      InitializeReader(out dict, out readerSession);
      using (var stream = new MemoryStream(buffer, false))
      {
        using (var reader = XmlDictionaryReader.CreateBinaryReader(stream, dict, new XmlDictionaryReaderQuotas(), readerSession))
        {
          var dcs = new DataContractSerializer(typeof(myLongRoot));
          var rootCopy = dcs.ReadObject(reader);
        }
      }
    }    
