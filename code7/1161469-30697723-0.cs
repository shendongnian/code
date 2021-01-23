    interface IMyObject
    {
       // common properties omitted
    }
    
    interface IMyObjectReader
    {
        IMyObject Parse(XElement xml, IMyObject parent);
    }
    public class MyFileObject:IMyObject
    {
        // common properties omitted
        public string Property1 { get; set; }
    }
    public class MyPictureObject:IMyObject
    {
        // common properties omitted
        public string Property2 { get; set; }
    }
    class MyFileObjectReader : IMyObjectReader
    {
        public IMyObject Parse(XElement xml, IMyObject parent)
        {
            var displayName = xml.Attribute("DisplayName").Value;
            return new MyFileObject(parent,displayName)
            {
                Property1 = xml.Attribute("Property1").Value
            };
        }
    }
    class MyPictureObjectReader : IMyObjectReader
    {
        public IMyObject Parse(XElement xml, IMyObject parent)
        {
            return new MyPictureObject(parent)
            {
                Property2 = xml.Attribute("Property2").Value
            };
        }
    }
    class MyObjectGraphXmlReader 
    {
        Dictionary<string, IMyObjectReader> readerMap;
        public MyObjectGraphXmlReader()
        {
            readerMap = new Dictionary<string, IMyObjectReader>
            {
                {"File", new MyFileObjectReader()},
                {"Picture", new MyFileObjectReader()},
                //etc
            };
        }
        public IEnumerable<IMyObject> ReadMyObjects(XElement xmlRoot) 
        {
            return xmlRoot.Elements()
                    .Select((e)=>ParseElement(e,null));
        }
        private IMyObject ParseElement(XElement element, IMyObject parent)
        {
            string readerKey = element.Attribute("Type").Value; 
            var reader = readerMap[readerKey];
            var myObject = reader.Parse(element, parent);
            foreach (var subElement in element.Elements())
            {
                ParseElement(subElement, parent);
            }
            return myObject;
        }
    }
  
