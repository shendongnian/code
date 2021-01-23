            var list = new List<string>();
            list.Add("HELLO");
            list.Add("hi");
            // save
            using (var fs = new FileStream(@"F:\test.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(fs, list);
            }
            // read
            using (var s = new FileStream(@"F:\test.xml", FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                List<string> result = (List<string>)serializer.Deserialize(s);
            }
