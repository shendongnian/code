    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Configuration config = new Configuration() {
                    configSections = new ConfigSections() {
                        section = new List<Section>() {
                           new Section() { name = "StationsSection", type="AcmeTV_EcFtpClient.StationConfigurationSection, AcmeTV_EcFtpClient"}
                        }
                    },
                    stationsSection = new StationsSection() {
                        station = new List<Station>() {
                            new Station() { 
                                add = new StationAdd() {
                                   comment ="My comment goes here",
                                   destinationFolderPath = "C:\\TestInstallation",
                                   ftpHostname = "ftp://upload.servername.com/",
                                   ftpFolderPath = "myFolderPath/",
                                   ftpUsername = "myUserName",
                                   ftpPassword = "myFtpPassword",
                                   ftpTimeoutInSeconds = 20
                                }
                            }
                        }
                    },
                    startup = new Startup() {
                        supportedRuntime = new SupportedRuntime() {
                            version = "v2.0.50727"
                        }
                    },
                    appSettings = new AppSettings() {
                        appSettingAdd = new List<AppSettingAdd>() {
                            new AppSettingAdd() { key= "NameOfService", value="AcmeECClient"},
                            new AppSettingAdd() { key="PollingFrequencyInSeconds", value="60"}
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, config);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Configuration  newConfig = (Configuration)xs.Deserialize(reader);
            }
        }
        [XmlRoot("configuration")]
        public class Configuration
        {
            [XmlElement("configSections")]
            public ConfigSections configSections { get; set; }
            [XmlElement("StationsSection")]
            public StationsSection stationsSection { get; set; }
         
            [XmlElement("startup")]
            public Startup startup { get; set; }
            [XmlElement("appSettings")]
            public AppSettings appSettings { get; set; }
        }
        [XmlRoot("configSections")]
        public class ConfigSections
        {
            [XmlElement("section")]
            public List<Section> section { get; set; }
        }
        [XmlRoot("section")]
        public class Section
        {
            [XmlAttribute("name")]
            public string name { get; set;}
            [XmlAttribute("type")]
            public string type { get; set; } 
        }
        [XmlRoot("StationsSection")]
        public class StationsSection
        {
            [XmlElement("Stations")]
            public List<Station> station  { get; set; }
        }
        [XmlRoot("Stations")]
        public class Station
        {
            [XmlElement("add")]
            public StationAdd add { get; set; }
        }
        [XmlRoot("add")]
        public class StationAdd
        {
            [XmlAttribute("Comment")]
            public string comment { get; set; }
            [XmlAttribute("DestinationFolderPath")]
            public string destinationFolderPath { get; set; }
            [XmlAttribute("FtpHostname")]
            public string ftpHostname { get; set; }
            [XmlAttribute("FtpFolderPath")]
            public string ftpFolderPath { get; set; }
            [XmlAttribute("FtpUsername")]
            public string ftpUsername { get; set; }
            [XmlAttribute("FtpPassword")]
            public string ftpPassword { get; set; }
            [XmlAttribute("FtpTimeoutInSeconds")]
            public int ftpTimeoutInSeconds { get; set; }
        }
        [XmlRoot("startup")]
        public class Startup
        {
            [XmlElement("supportedRuntime")]
            public SupportedRuntime supportedRuntime { get; set; }
        }
        [XmlRoot("supportedRuntime")]
        public class SupportedRuntime
        {
            [XmlAttribute("version")]
            public string version { get; set; }
        }
        [XmlRoot("appSettings")]
        public class AppSettings
        {
            [XmlElement("add")]
            public List<AppSettingAdd> appSettingAdd { get; set;}
        }
        [XmlRoot("add")]
        public class AppSettingAdd
        {
            [XmlAttribute("key")]
            public string key { get; set; }
            [XmlAttribute("value")]
            public string value { get; set; }
        }
    }
    ​
