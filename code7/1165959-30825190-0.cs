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
            static void Main(string[] args)
            {
                Person person = new Person();
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                MemoryStream stream = new MemoryStream();
                serializer.Serialize(stream, person); 
            }
        }
        public class Person
        {
        }
     
    }
    ​
