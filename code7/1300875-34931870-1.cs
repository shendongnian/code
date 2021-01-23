        XmlSerializer serializer = new XmlSerializer(typeof(Machine));
            using (System.IO.FileStream stream = new System.IO.FileStream(@"C:\Users\Administrator\Desktop\test.xml", System.IO.FileMode.Open))
            {
                Machine machine = (Machine)serializer.Deserialize(stream);
                Console.ReadKey();
            }
