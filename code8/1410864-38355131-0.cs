    var t = new Hashtable();
    t.Add("Hi!", "I'm here");
    t.Add("Hm", "Yup");
    
    var serializer = new XmlSerializer(typeof(Hashtable));
    
    using (var sw = new StringWriter())
    {
      serializer.Serialize(sw, t);
      
      Console.WriteLine(sw.ToString());
    }
