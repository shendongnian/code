    using (var xmlReader = XmlReader.Create(pathXmlFile))
    {
        if (xmlReader.ReadToFollowing("Header"))
        {
            XmlReader headerSubtree = xmlReader.ReadSubtree();
            XElement headerElement = XElement.Load(headerSubtree);
            // process headerElement
            Console.WriteLine(headerElement.Element("Type").Value);
            Console.WriteLine(headerElement.Element("Content").Value);
        }
    }
