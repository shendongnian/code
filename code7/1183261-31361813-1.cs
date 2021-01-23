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
                ArrayOfFoo aof = new ArrayOfFoo() {
                    foo = new Foo() {
                         FooString = "Hello Foo!",
                         barList = new List<BarList>() {
                            new BarList() {
                              bar = new Bar() {
                                  barString = "Hello Bar!"
                              }
                            }
                         }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfFoo));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, aof);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(ArrayOfFoo));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                ArrayOfFoo newAof = (ArrayOfFoo)xs.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "ArrayOfFoo")]
        public class ArrayOfFoo
        {
            [XmlElement("Foo")]
            public Foo foo { get; set; }
        }
         [XmlRoot(ElementName = "Foo")]
        public class Foo
        {
            [XmlElement("FooString")]
            public string FooString { get; set; }
            [XmlElement("BarList")]
            public List<BarList> barList { get; set; }
        }
        [XmlRoot(ElementName = "BarList")]
        public class BarList
        {
            [XmlElement("Bar")]
            public Bar bar { get; set; }
        }
        [XmlRoot(ElementName = "Bar")]
        public class Bar
        {
            [XmlElement("BarString")]
            public string barString { get; set; }
        }
        [XmlRoot(ElementName = "BarString")]
        public class BarString
        {
            [XmlText]
            public string value { get; set; }
        }​
    }
    ​
