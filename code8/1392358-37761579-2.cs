    static void Main(string[] args)
    {
            RegistrationOpenData RegistrationVal = null;
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "RegistrationOpenData";
            xRoot.Namespace = "http://services.hpd.gov";
            xRoot.IsNullable = true;
            var serializer = new XmlSerializer(typeof(RegistrationOpenData), xRoot);
            using (TextReader reader = new StreamReader(@"D:\sample.xml"))
            {
                RegistrationVal = (RegistrationOpenData)serializer.Deserialize(reader);
            }
    }
