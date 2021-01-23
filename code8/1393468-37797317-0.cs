        After you load the document in XmlDocument available in using System.Xml 
    namespace, you can create mutliple XmlNodeList(s) and then fetch the values.
    
             public static void foobar()
             {
                string strFile = @"C:\SourceFolder\SampleXML\document-test.xml";
                XmlDocument doc = XmlDocument.Load(strFile);
    
                if (doc.SelectSingleNode("w:body") != null)
                {
                   XmlNodeList nodes = doc.SelectNodes(".//w:pPr");
                   foreach (XmlNode xn in nodes)
                   {
                       XmlNodeList rPr = xn.SelectNodes("w:rPr");
                       foreach (XmlNode xnrPr in rPr)
                       {
                          if (xnrPr.SelectSingleNode("w:rFonts") != null)
                          {
                              Console.WriteLine(xnrPr.SelectSingleNode("w:rFonts").InnerText.ToString());
                          }
                       }
                   }
                }
