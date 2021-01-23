    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(School));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                School school = (School)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Teachers")]
        public class Teachers
        {
            [XmlElement("Teacher")]
            public List<Teacher> teacher { get; set; }
        }
        [XmlRoot("Teacher")]
        public class Teacher
        {
            //This is a made up annotation that represents what I'd like to happen.
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            //This is a made up annotation that represents what I'd like to happen.
            [XmlElement("Classes")]
            public List<Classes> Classes { get; set; }
        }
        [XmlRoot("Classes")]
        public class Classes
        {
            [XmlElement("Class")]
            public List<Class> c_class {get; set;} 
        }
        [XmlRoot("Class")]
        public class Class
        {
            //This is a made up annotation that represents what I'd like to happen.
            [XmlElement("Id")]
            public int Id { get; set; }
            [XmlElement("Subject")]
            public string Subject { get; set; }
            //This is a made up annotation that represents what I'd like to happen.
            [XmlElement("Teacher")]
            public Teacher Teacher { get; set; }
     
        }
        [XmlRoot("School")]
        public class School
        {
            public string Name { get; set; }
            public Classes Classes { get; set; }
            public Teachers Teachers { get; set; }
        }
    }
    ​
