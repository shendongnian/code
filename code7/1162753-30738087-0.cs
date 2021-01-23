    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Product));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Product XML = (Product)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Product")]
        public class Product
        {
            // Fields...
            // Properties    
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            private string Comments { get; set; }
            [XmlElement("Versions")]
            public Versions Versions { get; set; }
            // Constructors and methods...
        }
        [XmlRoot("Versions")]
        public class Versions
        {
            [XmlElement("Version")]
            public List<Version> Version { get; set; }
        }
        [XmlRoot("Version")]
        public class Version
        {
            // Fields...        
            // Properties
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Product")]
            public string Product { get; set; }
            [XmlElement("VersionNumber")]
            public string VersionNumber { get; set; }
            [XmlElement("Comments")]
            public string Comments { get; set; }
            [XmlElement("Resources")]
            public Resources Resources { get; set; }
            // Constructors and methods...
        }
        [XmlRoot("Resourses")]
        public class Resources
        {
            [XmlElement("Resource")]
            public List<Resource> Resource { get; set; }
        }
        [XmlRoot("Resourse")]
        public class Resource
        {
            // Fields...        
            // Properties
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("Uri")]
            public string Uri { get; set; }
            private string Comments { get; set; }
            [XmlElement("Properties")]
            public Properties Properties { get; set; }
        }
            // Constructors and methods.
        [XmlRoot("Properties")]
        public class Properties
        {
            [XmlElement("Property")]
            public List<Property> properties { get; set; }
        }
        [XmlRoot("Property")]
        public class Property
        {
            // Fields...
            // Properties
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("PropertyTypeId")]
            public string PropertyTypeId { get; set; }
            private int? MaximumStringLength { get; set; }
            private double? MinimumValue { get; set; }
            private double? MaximumValue { get; set; }
            [XmlElement("EnumerationId")]
            public int? EnumerationId { get; set; }
            private int? ResourceId { get; set; }
            private string Comments { get; set; }
            [XmlElement("Enumeration")]
            public Enumeration Enumeration { get; set; }
            // Constructors and methods...
        }
        [XmlRoot("Enumeration")]
        public class Enumeration
        {
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("Members")]
            public Members Members { get; set; }
        }
        [XmlRoot("Members")]
        public class Members
        {
            [XmlElement("Member")]
            public List<Member> Member { get; set; }
        }
        [XmlRoot("Member")]
        public class Member
        {
            [XmlElement("Name")]
            public string Name { get; set; }
        }
    }
    ​
