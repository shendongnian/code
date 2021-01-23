        private static IEnumerable<XElement> StreamElements(string fileName, params string[] elementsName)         
        {
              using (var rdr = XmlReader.Create(fileName))
              {
                  rdr.MoveToContent();
                  while (rdr.Read())
                  {
                      if ((rdr.NodeType == XmlNodeType.Element) && (elementsName.Contains(rdr.Name)))
                      {
                          var e = XElement.ReadFrom(rdr) as XElement;
                          yield return e;
                      }
                  }
                  rdr.Close();
              }
         }
