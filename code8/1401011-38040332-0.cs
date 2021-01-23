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
                string path = @"c:\temp\test.xml";
                XmlSerializer serializer = new XmlSerializer(typeof(DirectoryListener));
                StreamReader reader = new StreamReader(path);
                DirectoryListener directoryListener = (DirectoryListener)serializer.Deserialize(reader);//Throw an exception
            }
        }
        [XmlRoot("DirectoryListener")]
        public partial class DirectoryListener
        {
            private string inputDirectoryField;
            private string outputDirectoryField;
            private string fileExtField;
            [XmlAttribute("inputDirectory")]
            public string inputDirectory {get; set; }
            [XmlAttribute("outputDirectory")]
            public string outputDirectory { get; set; }
            [XmlAttribute("fileExt")]
            public string fileExt { get; set; }
        }
    }
