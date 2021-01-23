    using System;
    using System.Xml;
    
    namespace ConfigModifier
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument xmlDoc = new XmlDocument();
                string fileName = @"C:\Some\entered\path\appName.exe.config";
                xmlDoc.Load(fileName);
                xmlDoc["configuration"]["applicationSettings"]["WindowsService2.Properties.Settings"]["setting"]["value"].InnerText = "My New Value";
                xmlDoc.Save(fileName);
                Console.ReadKey(true);
            }
        }
    }
