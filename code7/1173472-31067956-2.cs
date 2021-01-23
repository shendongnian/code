        static void Main(string[] args) {
      //Ideally you should have well formed xml with root element as eg given below
      //but since it is stream it is possible but not sure how much control you have on it.
      //eg: <Nodes><Node1/><Node2/>...</Nodes> 
      //Reading your data from locally stored stream files
      var streamFiles=new[] { @"C:\temp\stack\xml1.xml", @"C:\temp\stack\xmlN.xml" };
      var dict = new Dictionary<int,XElement>();
      foreach(var streamFile in streamFiles) {
        using(var reader=XmlReader.Create(streamFile, new XmlReaderSettings { ConformanceLevel=ConformanceLevel.Fragment })) {
          var nodeNo=0;
          while(reader.MoveToContent()==XmlNodeType.Element) {
            var element=XNode.ReadFrom(reader) as XElement;
            //Now merge the data. Yahoo
            XElement currentElement;
            if(!dict.TryGetValue(nodeNo, out currentElement)) {
              currentElement = new XElement("Node");
              dict.Add(nodeNo, currentElement);
            }
            foreach(var el in element.Elements().Where(e => !e.HasElements)) {
              currentElement.SetElementValue(el.Name, el.Value);
            }
            currentElement.SetElementValue("NodeNEW",
              element.Elements().Where(e => e.HasElements)
                .SelectMany(e => e.Elements()
                  .Where(w => w.Name=="Att"))
                .FirstOrDefault().Value);
            var valueElement = element.Elements().Where(e => e.HasElements)
              .SelectMany(e => e.Elements()
                .Where(w => w.Name!="Att"));
            currentElement.Add(element.Elements().Where(e => e.HasElements)
              .SelectMany(e => e.Elements()
                .Where(w => w.Name!="Att")));
            nodeNo++;
          }
        }
      }
      using(var writer=XmlWriter.Create(@"C:\temp\stack\xmlMerged.xml",
        new XmlWriterSettings {
          ConformanceLevel=ConformanceLevel.Fragment,
          Indent=true
        })) {
        foreach(var element in dict.Values) {
          element.WriteTo(writer);
        }
      }
    }
