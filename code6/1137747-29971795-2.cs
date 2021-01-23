    Class saveABCObjects(list<objects> ABCObjects)
    {
      using(var sync = new SynchronizedXMLAccess(...)) 
      {
        XmlSerializer serializer = new XmlSerializer(typeof(List<objects>));
        TextWriter textWriter = new StreamWriter(sync.Fs);
        serializer.Serialize(textWriter, ABCObjects);
        textWriter.Close();
      }
    }
