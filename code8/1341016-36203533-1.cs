            Contents dezerializedXML = new Contents();
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Contents));
            using (FileStream stream = File.OpenRead(@"xml.xml"))
            {
                dezerializedXML = (Contents)serializer.Deserialize(stream);
            } // Put a break-point here, then mouse-over dezerializedXML
