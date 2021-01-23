        string strXml;
	    try
        {
            using (StreamReader sr = new StreamReader("myXML.xml"))
            {
                 strXml = sr.ReadToEnd();
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strXml);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
