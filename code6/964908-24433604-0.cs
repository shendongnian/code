        string filename = "SOAP.xml";
        XmlDocument document = new XmlDocument();
        document.Load(filename);
        XPathNavigator navigator = document.CreateNavigator();
        // use XmlNamespaceManager to resolve ns prefixes
        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("h", "http://tempuri.org/");
        // use XPath expression to select XML nodes
        XPathNodeIterator nodes = navigator.Select("//h:SecurityToken",manager);
        if ( nodes.MoveNext() )
            Console.WriteLine(nodes.Current.ToString());
        else
            Console.WriteLine("Empty Element");
        // and now for the Signature Element, without ns prefix
        nodes = navigator.Select("//Signature", manager);
        nodes.MoveNext();
        if (nodes.MoveNext())
            Console.WriteLine(nodes.Current.ToString());
        else
            Console.WriteLine("Empty Element");
