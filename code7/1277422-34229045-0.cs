    using System;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            var originalRoot = doc.DocumentElement;
            doc.RemoveChild(originalRoot);
            var newRoot = doc.CreateElement("userBooks");
            doc.AppendChild(newRoot);
            newRoot.AppendChild(originalRoot);
            doc.Save(Console.Out);
        }
    }
