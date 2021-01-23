    public static int GetImmediateChildrenCount(Stream stm)
    {
      using(stm)
      {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.CheckCharacters = false; //optomisation - best avoided.
        settings.DtdProcessing = DtdProcessing.Ignore;
        int count = 0;
        using(XmlReader rdr = XmlReader.Create(stm, settings))
        {
          while(rdr.Read())
            if(rdr.NodeType == XmlNodeType.Element)
              while(rdr.Read())
                if(rdr.NodeType == XmlNodeType.Element)
                {
                  ++count;
                  rdr.ReadSubtree().Dispose();
                }
        }
        return count;
      }
    }
