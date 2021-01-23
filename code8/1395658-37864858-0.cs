    while (reader.Read()) {
      if (!reader.IsStartElement("WebError")) { continue; }
      // We found the WebError node
      using (var nodeReader = reader.ReadSubtree()) {
        nodeReader.MoveToContent();
        // Read the attributes
        while (nodeReader.MoveToNextAttribute()) {
          var nodeName = nodeReader.LocalName;
          if (nodeName == "Key") {
            m_Key = nodeReader.Value; // "A"
            break;
          }
        }
        // Read the XML sub nodes
        while (nodeReader.Read()) {
          if (nodeReader.NodeType != XmlNodeType.Element) { continue; }
          using (var subLevelReader = nodeReader.ReadSubtree()) {
            // Parse sub levels of XML (Message, Parameters)
          }
        }
      }
    }
