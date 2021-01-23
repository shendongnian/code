    void GetData(out Tuple<string, string> extracted) {
      extracted = null;
      // ...
      extracted = xDoc.Root.Elements()
                      .OrderBy(x => (string)x.Attribute("name"))
                      .Select(n => Tuple.Create(
                                           n.Attribute("name").Value, 
                                           n.Element("Status").Value
                      ));
                   );
    }
