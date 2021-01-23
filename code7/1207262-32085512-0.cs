      XmlNodeList fileNodeLIst = fileNode.SelectNodes("file");
        for(int iNode = fileNodeList.Count - 1; iNode >= 0; iNode --)
          {
            XmlNode file = fileNodeLIst[iNode];
            if(file.Attributes["type"].Value == "undeletable"){
                TerminalSystemAddMessage("Error: Unable to delete " + file.Attributes["name"].Value);
            }else if(file.Attributes["type"].Value == "deletable"){
                file.ParentNode.RemoveChild(file);
                TerminalSystemAddMessage("Deleted: " + file.Attributes["name"].Value);
            }
          }
