    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                SetClientiXML client = new SetClientiXML()
                {
                    xmlRequest = new XMLRequest()
                    {
                        arrayOfWrapClienti = new ArrayOfWrapClienti()
                        {
                            wrapClient = new List<WrapClient>() {
                                new WrapClient {
                                    codrete = "0018",
                                    codice = "20685",
                                    nome = "A.T.E.R. Azienda Territoriale",
                                    indirizzo = "PIAZZA POZZA",
                                    citta = "Verona",
                                    cap = "37123",
                                    prov = "VR",
                                    codiceFiscale = "00223640236",
                                    piva = "223640236",
                                    esposizContabile = "937,02",
                                    stato = false
                                }
                            }
                        }
                    },
                    retista = "3303903",
                    hashedString = "oklkokokokok"
                };
                XmlSerializer serializer = new XmlSerializer(typeof(SetClientiXML));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, client);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(SetClientiXML));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                SetClientiXML newClient = (SetClientiXML)xs.Deserialize(reader);
            }
        }
        [XmlRoot("SetClientiXML")]
        public class SetClientiXML
        {
            [XmlElement("XMLRequest")]
            public XMLRequest xmlRequest { get; set; }
            [XmlElement("RETISTA")]
            public string retista { get; set; }
            [XmlElement("HASHEDSTRING")]
            public string hashedString { get; set; }
        }
        [XmlRoot("XMLRequest")]
        public class XMLRequest
        {
            [XmlElement("ArrayOfWrapClienti")]
            public ArrayOfWrapClienti arrayOfWrapClienti { get; set; }
        }
        [XmlRoot("ArrayOfWrapClienti")]
        public class ArrayOfWrapClienti
        {
            [XmlElement("WrapClient")]
            public List<WrapClient> wrapClient { get; set; }
        }
        [XmlRoot("WrapClient")]
        public class WrapClient
        {
            [XmlElement("CODRETE")]
            public string codrete { get; set; }
            [XmlElement("CODICE")]
            public string codice { get; set; }
            [XmlElement("NOME")]
            public string nome { get; set; }
            [XmlElement("INDIRIZZO")]
            public string indirizzo { get; set; }
            [XmlElement("CITTA")]
            public string citta { get; set; }
            [XmlElement("CAP")]
            public string cap { get; set; }
            [XmlElement("PROV")]
            public string prov { get; set; }
            [XmlElement("CODICEFISCALE")]
            public string codiceFiscale { get; set; }
            [XmlElement("PIVA")]
            public string piva { get; set; }
            [XmlElement("EMAIL")]
            public string email { get; set; }
            [XmlElement("ESPOSIZ_CONTABILE")]
            public string esposizContabile { get; set; }
            [XmlElement("STATO")]
            public Boolean stato { get; set; }
        
        }
    }
    ​
