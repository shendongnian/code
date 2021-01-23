    public static class BaseFactory 
    {
        public static Base GetBase(string id) 
        { 
            switch(id) { case '1': return new Base1(); ... }
        }
        
        public static T GetBaseList<T>(string xml, string tagName) where T: Base
        {
            List<T> list = new List<T>();
            var nodes = XDocument.Load(xml).Descendants(tagName);
            foreach(XElement node in nodes)
            {
                var base = GetBase(node.Attribute("id").Value);
                base.SetPropertiesFromXml(node);
                list.Add(base as T);
            }
        }
    }
