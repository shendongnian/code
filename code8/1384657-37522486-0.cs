            string markup = "<X><Y><Z></Z><Z></Z><Z></Z></Y></X>";
            //string markup = "<Root>Content</Root>";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.MaxCharactersInDocument = 10;
        try
        {
            XmlReader reader = XmlReader.Create(new StringReader(markup), settings);
            while (reader.Read()) { }
        }
        catch (XmlException ex)
        {
            Console.WriteLine(ex.Message);
        }
