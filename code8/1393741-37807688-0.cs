            using(XmlReader reader = XmlReader.Create(new FileStream(@"D:\Registrations20160229.xml" , FileMode.Open))){
                            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element && reader.Name == "Registration")
                    counter++;
            }
            Console.WriteLine(counter);
            }
