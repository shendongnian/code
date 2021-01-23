     XDocument xmlDoc =  XDocument.Load(xml);
                var pageInfo = (from xml2 in xmlDoc.Descendants("PageInfo")
                                where xml2.Element("ID").Value == "0"
                                || xml2.Element("NUM").Value == "5"
                                || xml2.Element("URL").Value == "er.php"
                                    select xml2).FirstOrDefault();
    
                pageInfo.Remove();
                xmlDoc.Save(xml);
