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
                SplashScreen splashScreen = new SplashScreen()
                {
                    image = new Image()
                    {
                        Path = "Content/splash"
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(SplashScreen));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, splashScreen);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(SplashScreen));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                SplashScreen  newSplashScreen = (SplashScreen)xs.Deserialize(reader);
            }
        }
        [XmlRoot("SplashScreen")]
        public class SplashScreen
        {
            [XmlElement("Image")]
            public Image image {get; set; }
        }
        [XmlRoot("Image")]
        public class Image
        {
            [XmlElement("Path")]
            public string Path {get; set;}
        }
        
    }
    ​
