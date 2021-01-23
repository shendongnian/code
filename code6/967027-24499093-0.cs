            XmlWriter writer;
            writer = XmlWriter.Create( @"C:\users\kthomp08\desktop\test.xml" );
            
            writer.WriteStartDocument();
            writer.WriteStartElement( "TestElement" );
            writer.WriteRaw( "Hello & goodbye" );
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
