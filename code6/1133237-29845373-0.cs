    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication19
    {
        class Program
        {
            const string FILENAME = @"c:\temp\Test.xml";
            static void Main(string[] args)
            {
               ArrayOfGebruiker arrayOfGebruiker = new ArrayOfGebruiker(){
                   Gebruiker = new List<Gebruiker>(){
                       new Gebruiker {
                           antwoorden = new I() { nil = true},
                           bevestigWachtwoord = "test123",
                           dossiersAlsMedebeheerder = new I(){ nil =true},
                           familienaam = "VG",
                           geboorteDatum = DateTime.Parse("1993-04-10T00:00:00"),
                           gebruikerID = 1,
                           gebruikerStatus = "Toegelaten",
                           gebruikersnaam = "Laurens",
                           gebruikerstype = "Expert",
                           gemeente = "Leuven",
                           LaatstGezien = DateTime.Parse("2009-04-10T00:00:00"),
                           likes = new I(){ nil = true},
                           mailAdres = "Laurens.vg@gmail.com",
                           modulesAlsExpert = new I(){nil = true},
                           postcode = 8000,
                           voornaam = "Laurens",
                           wachtwoord = "test123"
                       }
                   }
               };
               XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfGebruiker));
               StreamWriter writer = new StreamWriter(FILENAME);
               XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
               //_ns.Add("", "");
               //serializer.Serialize(writer, icp, _ns);
               serializer.Serialize(writer, arrayOfGebruiker);
               writer.Flush();
               writer.Close();
               writer.Dispose();
               XmlSerializer xs = new XmlSerializer(typeof(ArrayOfGebruiker));
               XmlTextReader reader = new XmlTextReader(FILENAME);
               ArrayOfGebruiker newArrayOfGebruiker = (ArrayOfGebruiker)xs.Deserialize(reader);
                     
            }
        }
        [XmlRoot("ArrayOfGebruiker")]
        public class ArrayOfGebruiker
        {
            [XmlElement("Gebruiker")]
            public List<Gebruiker> Gebruiker {get;set;}
        }
        [XmlRoot("Gebruiker")]
        public class Gebruiker
        {
            [XmlElement("Antwoorden")]
            public I antwoorden {get;set;}
            [XmlElement("BevestigWachtwoord")]
            public string bevestigWachtwoord {get;set;}
            [XmlElement("DossiersAlsMedebeheerder")]
            public I dossiersAlsMedebeheerder {get;set;}
            [XmlElement("Familienaam")]
            public string familienaam {get;set;}
            [XmlElement("GeboorteDatum")]
            public DateTime geboorteDatum {get;set;}
            [XmlElement("GebruikerID")]
            public int gebruikerID {get;set;}
            [XmlElement("GebruikerStatus")]
            public string gebruikerStatus {get;set;}
            [XmlElement("Gebruikersnaam")]
            public string gebruikersnaam {get;set;}
            [XmlElement("Gebruikerstype")]
            public string gebruikerstype {get;set;}
            [XmlElement("Gemeente")]
            public string gemeente {get;set;}
            [XmlElement("LaatstGezien")]
            public DateTime LaatstGezien {get;set;}
            [XmlElement("Likes")]
            public I likes {get;set;}
            [XmlElement("MailAdres")]
            public string mailAdres {get;set;}
            [XmlElement("ModulesAlsExpert")]
            public I modulesAlsExpert {get;set;}
            [XmlElement("Postcode")]
            public int postcode {get;set;}
            [XmlElement("Voornaam")]
            public string voornaam {get;set;}
            [XmlElement("Wachtwoord")]
            public string wachtwoord {get;set;}
        }
        public class I
        {
            [XmlAttribute(AttributeName = "nil")]
            public bool nil {get;set;}
        }
