    StreamReader objSR = new StreamReader(response.GetResponseStream()); //get the soap from a server
    string strResponse = objSR.ReadToEnd();
    XmlDocument xDoc = new XmlDocument();
    xDoc.LoadXml(strResponse);
    XmlNodeList name = xDoc.GetElementsByTagName("returnval");
    try
    {
        Console.WriteLine(name[0].InnerText + name[0].Attributes[0].InnerText);
        Console.ReadLine();
    }
    catch { Exception e; }
