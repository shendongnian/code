    XmlSerializer deserializer = new XmlSerializer(typeof(Project));
            StreamReader reader = new StreamReader(xml);
            object obj = deserializer.Deserialize(reader);
            Project XmlData = (Project)obj;
            reader.Close();
            var val = XmlData.Subsystems.ToList().Where(x=>x.Values.ToList().Select(y=>y.Name).Contains("Thing2")).ToList();
