    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                a.properties = new List<Property>()
                {
                    new Property(Humanity.PropertyTypeEnum.String, "name", "file1.pdf"),
                    new Property(Humanity.PropertyTypeEnum.Timestamp, "creationDate", DateTime.Now)
                };
    
                //String name = a.Name;
                //DateTime creationDate = a.CreationDate;
                //a.Name = "otherName";
                //a.CreationDate = creationDate.AddDays(1);
    
                String name = (String)a["name"];
                DateTime creationDate = (DateTime)a["creationDate"];
                a["name"] = "otherName";
                a["creationDate"] = creationDate.AddDays(1);
            }
    
            public class A
            {
                private Dictionary<Property, object> myvalues = new    Dictionary<Property, object>();
                public List<Property> properties;
    
                public object this[string name]
                {
                    get
                    {
                        var prop = properties.Find(p => p.key == name);
                        if (prop == null)
                            throw new Exception("property " + name + " not  found.");
                        return prop.value;
                    }
                    set
                    {
                        var prop = properties.Find(p => p.key == name);
                        if (prop == null)
                            throw new Exception("property " + name + " not found.");
                        prop.value = value;
                    }
                }
            }
    
            public class Property
            {
                public Property(Humanity.PropertyTypeEnum type, string key,     object value) { this.type = type; this.key = key; this.value =    value; }
                private Humanity.PropertyTypeEnum type;
                public string key;
                public object value;
            }
        }
    }
    
    namespace Humanity
    {
        public enum PropertyTypeEnum { String, Timestamp };
        public enum FeedTypeEnum { };
    }
