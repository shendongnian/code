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
                Site site = new Site()
                {
                    name = "MyTestSite",
                    url = "http://mytesturl",
                    children = new Children()
                    {
                        page = new Page()
                        {
                            address =  "HomePage",
                            children = new Children()
                            {
                                button = new Button()
                                {
                                    name = "SomeButton",
                                    id = "SomeID",
                                    xPath = "SomePath",
                                    enabled = true,
                                    action = "OpenLoginDialog"
                                },
                                dialog = new Dialog()
                                {
                                    name = "LoginPopUpDialog",
                                    children = new Children()
                                    {
                                        staticText = new StaticText()
                                        {
                                            name = "LoginSuccessMessage",
                                            id = "SomeID",
                                            xPath = "SomePath",
                                            value = "Hello"
                                        },
                                        button = new Button()
                                        {
                                            name = "OkButton",
                                            value = "SomeString",
                                            id = "SomeID",
                                            xPath = "SomePath",
                                            action = "DialogDismiss"
                                        }
                                    }
                                },
                                checkBox = new CheckBox()
                                {
                                    name = "SomeCheckBox",
                                    id = "SomeID",
                                    xPath = "SomePath",
                                    enabled = true,
                                    m_checked = true
                                }
                            }
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Site));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, site);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Site));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Site newSite = (Site)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Site")]
        public class Site
        {
            [XmlElement("Children")]
            public Children children { get; set; }
            [XmlElement("Name")]
            public string name { get; set; }
            [XmlElement("Url")]
            public string url { get; set; }
        }
        [XmlRoot("Children")]
        public class Children
        {
            [XmlElement("Page")]
            public Page page { get; set; }
            [XmlElement("Button")]
            public Button button { get; set; }
            [XmlElement("Dialog")]
            public Dialog dialog { get; set; }
            [XmlElement("CheckBox")]
            public CheckBox checkBox { get; set; }
            [XmlElement("StaticText")]
            public StaticText staticText { get; set; }
        }
        [XmlRoot("Page")]
        public class Page
        {
            [XmlElement("Address")]
            public string address { get; set; }
            [XmlElement("Children")]
            public Children children { get; set; }
        }
        [XmlRoot("Button")]
        public class Button
        {
            [XmlElement("Name")]
            public string name { get; set; }
            [XmlElement("Value")]
            public string value { get; set; }
            [XmlElement("Id")]
            public string id { get; set; }
            [XmlElement("XPath")]
            public string xPath { get; set; }
            [XmlElement("DialogDismiss")]
            public string dialogDismiss { get; set; }
            [XmlElement("Enabled")]
            public Boolean enabled { get; set; }
            [XmlElement("Action")]
            public string action { get; set; }
        }
        [XmlRoot("Dialog")]
        public class Dialog
        {
            [XmlElement("Name")]
            public string name { get; set; }
            [XmlElement("Children")]
            public Children children { get; set; }
        }
        [XmlRoot("CheckBox")]
        public class CheckBox
        {
            [XmlElement("Name")]
            public string name { get; set; }
            [XmlElement("Id")]
            public string id { get; set; }
            [XmlElement("XPath")]
            public string xPath { get; set; }
            [XmlElement("Enabled")]
            public Boolean enabled { get; set; }
            [XmlElement("Checked")]
            public Boolean m_checked { get; set; }
        }
        [XmlRoot("StaticText")]
        public class StaticText
        {
            [XmlElement("Name")]
            public string name { get; set; }
            [XmlElement("Id")]
            public string id { get; set; }
            [XmlElement("XPath")]
            public string xPath { get; set; }
            [XmlElement("Value")]
            public string value { get; set; }
        }
    }
