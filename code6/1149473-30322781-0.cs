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
            const string FILENAME = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                StatisticsFunctionsSetting settings = new StatisticsFunctionsSetting(){
                    statisticsFunctions = new List<StatisticsFunctions>(){
                        new StatisticsFunctions(){
                            visibility = new List<bool>(){true,true, false}
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(StatisticsFunctionsSetting));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, settings, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(StatisticsFunctionsSetting));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                StatisticsFunctionsSetting  newSettings = (StatisticsFunctionsSetting)xs.Deserialize(reader);
            }
        }
        [XmlRoot("StatisticsFunctionsSetting")]
        public class StatisticsFunctionsSetting
        {
            [XmlElement("StatisticsFunctions")]
            public List<StatisticsFunctions> statisticsFunctions {get;set;}
        }
        [XmlRoot("StatisticsFunctions")]
        public class StatisticsFunctions
        {
            [XmlElement("Visibility")]
            public List<Boolean> visibility { get; set; }
        }
        
    }
