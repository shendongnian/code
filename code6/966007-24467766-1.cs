    static IEnumerable<XElement> EnumerateAxis(XmlReader reader, string axis)
    {
      reader.MoveToContent();
      while (reader.Read())
      {
        switch (reader.NodeType)
        {
          case XmlNodeType.Element:
            if (reader.Name == axis)
            {
              XElement el = XElement.ReadFrom(reader) as XElement;
              if (el != null)
                yield return el;
            }
            break;
        }
      }
    }
    ...
    Parallel.ForEach(EnumerateAxis(reader, "Input"), node =>
    { 
      nodeParams np = new nodeParams();
    
    // do calc and put result in np and add to cd using Case as a Key
    
      });
    
    // Update XML doc based on the content of cd
