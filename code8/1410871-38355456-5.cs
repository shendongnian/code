            var hash = new System.Collections.Hashtable();
            hash[7] = "7";
            hash[8] = "8";
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Hashtable));
            TextWriter writer = new System.IO.StreamWriter(@"C:\SomeFile.xml");
            serializer.Serialize(writer, hash);
