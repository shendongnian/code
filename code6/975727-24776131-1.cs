    private void Analyze( IEnumerable<XElement> inputData)
        {
            XElement rootElement = null;
            if(status)
            {
              rootElement = new XElement("Items",
              from singleInputItem in inputData
              select new XElement("Element",
                   new XAttribute("ID", "default ID"),
                   new XAttribute("Type", "default type"),
                   new XElement("Content", getContent());     
                   new XElement("Width", 120),
                   new XElement("Height",150)
                 ));
            }
            else
            {
              rootElement = new XElement("Items",
              from singleInputItem in inputData
              select new XElement("Element",
                   new XAttribute("ID", "default ID"),
                   new XAttribute("Type", "default type"),     
                   new XElement("Width", 120),
                   new XElement("Height",150)
                 ));
            }
        }
