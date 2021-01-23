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
                LogModel logModels = new LogModel()
                {
                    Message = "Hello",
                    LogDate = DateTime.Now,
                    Level = 123,
                    Type = "Red",
                    Source = "Web",
                    StartDateTime = DateTime.Now.AddHours(-1),
                    EndDateTime = DateTime.Now.AddHours(2),
                    Owner = "Me",
                    Parameters = new List<LogModelParameter>() {
                        new LogModelParameter() {
                            ParameterDate = DateTime.Now,
                            Level = 5,
                            Counter = -1,
                            Type = "Banana",
                            Text = "Hello"
                        },
                        new LogModelParameter() {
                            ParameterDate = DateTime.Now.AddHours(1),
                            Level = 4,
                            Counter = 0,
                            Type = "Peach",
                            Text = "Goodbye"
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(LogModel));
                TextWriter writer = new StreamWriter("log.xml");
                serializer.Serialize(writer, logModels);
                
            }
        }
        public class LogModel
        {
            [XmlText]
            public String Message { get; set; }
            [XmlAttribute]
            public DateTime LogDate { get; set; }
            [XmlAttribute]
            public Int32 Level { get; set; }
            [XmlAttribute]
            public String Type { get; set; }
            public String Source { get; set; }
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }
            public String Owner { get; set; }
            [XmlElement("Parameters")]
            public List<LogModelParameter> Parameters { get; set; }
        }
        public class LogModelParameter
        {
            [XmlAttribute]
            public DateTime ParameterDate { get; set; }
            [XmlAttribute]
            public Int32 Level { get; set; }
            [XmlAttribute]
            public Int32 Counter { get; set; }
            [XmlAttribute]
            public String Type { get; set; }
            [XmlText]
            public String Text { get; set; }
        }
    }
    ​
