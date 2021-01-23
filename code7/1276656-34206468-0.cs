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
                Vehicle vehicle = new Vehicle() {
                    Type = new Type()
                    {
                        ISN = "213123214",
                        Name = "ddsd"
                    },
                    RegNo = 1234,
                    Brand = new Mark()
                    {
                        ISN = "423434234",
                        Name = "asdasd"
                    },
                    Model = new Mark()
                    {
                        ISN = "434234324324",
                        Name = "asddsa"
                    },
                    estimation = new Estimation()
                    {
                        Amount = 15000,
                        AmountPrev = null,
                        currency = new Currency()
                        {
                            Code = "R",
                            Name = "RU"
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Vehicle));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, vehicle);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
        [XmlRoot("Vehicle")]
        public class Vehicle
        {
            [XmlElement("Type")]
            public Type Type { get; set; }
            [XmlElement("Mark")]
            public Mark Brand { get; set; }
            [XmlElement("Model")]
            public Mark Model { get; set; }
            [XmlElement("RegNo")]
            public int RegNo { get; set; }
            [XmlElement("EstimatedPrice")]
            public Estimation estimation { get; set; }
        }
        [XmlRoot("EstimationPrice")]
        public class Estimation
        {
            [XmlElement("Amount")]
            public int Amount { get; set; }
            [XmlElement("AmountPrev")]
            public int? AmountPrev { get; set; }
            [XmlElement("Currency")]
            public Currency currency { get; set; }
        }
        [XmlRoot("Currency")]
        public class Currency
        {
            [XmlElement("Code")]
            public string Code { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
        }
        [XmlRoot("Type")]
        public class Type : ResponseItem
        {
        }
        [XmlRoot("Mark")]
        public class Mark : ResponseItem
        {
        }
        [XmlRoot("ResponseItem")]
        public class ResponseItem
        {
            [XmlElement("ISN")]
            public string ISN { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
        }
    }
    ​
