          foreach(var cmd in XmlFiles)
          {
             using (XmlReader r = cmd.ExecuteXmlReader())
             {
                  r.MoveToContent();
                  writer.WriteNode(r, false);
              }
          }
