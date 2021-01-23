    You can give this a try. This is simple and subtle.
    
       using System;
       using System.IO;
       using System.Xml.Serialization;
       using System.Xml;
       using System.Text;
    
       namespace ConsoleApplication1
       {
           class Program
           {
                static void Main(string[] args)
                {
                     Employee emp = new Employee
                     {
                         Name = new Item { Key = "Name", Value = "XYZ" },
                         Phone = new Item { Key = "Phone", Value = "007987" },
                         DOB = new Item { Key = "Date of Birth", Value = "Some Date"},
                         Id = new Item { Key = "Employee ID", Value = "A ID" },
                     };
    
                var ser = new XmlSerializer(typeof(Employee));
    
                using (var fs = new StreamWriter("your path", false))
                {
                    ser.Serialize(fs, emp);
                }
    
                var emp2 = ser.Deserialize(new StreamReader("your path"));
            }
        }
    
        public class Employee
        {
            [XmlElement(ElementName = "item1")]
            public Item Name { get; set; }`enter code here`
    
            [XmlElement(ElementName = "item2")]
            public Item Phone { get; set; }
    
            [XmlElement(ElementName = "item3")]
            public Item DOB { get; set; }
    
            [XmlElement(ElementName = "item4")]
            public Item Id { get; set; }
        }
    
        public class Item
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
