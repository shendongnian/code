    string sXML = Encoding.UTF8.GetString(bary); doc.LoadXml(sXML);
    string sNode = oSelectNodes[0].InnerText;
    sNode = System.Web.HttpUtility.HtmlDecode(sNode);
    sNode = Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-9").GetBytes(sNode));
     
