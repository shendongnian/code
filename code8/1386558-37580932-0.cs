    using System;
    using System.IO;
    using System.Xml;
    namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            var file = File.ReadAllText("c:\\temp\\file.xml");
            var xmlFile = new XmlDocument();
            xmlFile.LoadXml(file);
            var filterElements = xmlFile.GetElementsByTagName("Filter");
            foreach (XmlNode filterNode in filterElements) {
                var filterName = filterNode.Attributes[0].Name;
                var filterText = filterNode.Attributes[0].InnerXml;
                var destination = filterNode.ParentNode.Attributes["Destination"].InnerText;
                var message = string.Format("the destination {0} will filter {1} by {2}", destination, filterName, filterText);
                Console.WriteLine(message);
            }
            Console.ReadKey();
        }
    }
