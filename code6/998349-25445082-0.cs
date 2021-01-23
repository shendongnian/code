    static void Main(string[] args)
        {
            ReadXML("Test.xml");
        }
        private static void ReadXML(string filepath)
        {
            try
            {
                string xmlDatapath = filepath;
                string FirstColumn = "";
                string SecondColumn = "";
                string xmlData = File.ReadAllText(xmlDatapath);
                StringReader stream = new StringReader(xmlData);
                XmlTextReader reader = new XmlTextReader(stream);
                DataSet xmlDS = new DataSet();
                xmlDS.ReadXml(reader);
                FirstColumn = xmlDS.Tables[0].Rows[0][0].ToString();
                SecondColumn = xmlDS.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception ex)
            {
            }
        }
