    public static int GetImmediateChildrenCount(Stream stm)
    {
      using(stm)
      {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.CheckCharacters = false; //optomisation - best avoided.
        settings.DtdProcessing = DtdProcessing.Ignore;
        int count = 0;
        int curDepth = 0;
        using(XmlReader rdr = XmlReader.Create(stm, settings))
          while(rdr.Read())
            switch(rdr.NodeType)
            {
              case XmlNodeType.Element:
                if(rdr.IsEmptyElement)
                {
                  if(curDepth == 1)
                    ++count;
                }
                else if(curDepth++ == 1)
                  ++count;
              break;
              case XmlNodeType.EndElement:
                if(--curDepth == 0)
                  return count;
              break;
            }
        return count;
      }
    }
