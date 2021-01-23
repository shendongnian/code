    using (XmlReader reader = cmd.ExecuteXmlReader()) //e.command.commandtimeout = 500
        {
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var writer = XmlTextWriter.Create(@"\\file\.xml", settings))
            {
               while (reader.Read())
               {
                //  string s = reader.ReadOuterXml();
                    XmlDocument dom = new XmlDocument();
                    dom.Load(reader);
                    dom.WriteContentTo(writer);
               }
            }
        reader.Close();
    }
