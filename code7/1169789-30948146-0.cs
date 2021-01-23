    string file = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "xml.txt");
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(file);
                var el = xmlDoc.SelectSingleNode("/Fare_1");
                var c = el.ChildNodes;
                List<string> rateClassValues = new List<string>();
                foreach (XmlNode x in c)
                {
                   foreach(XmlNode ch in x.ChildNodes)
                   {
                       var rateClassValue = ch.FirstChild.NextSibling.FirstChild.FirstChild.InnerText;
                       if (!rateClassValues.Contains(rateClassValue))
                       {
                           // add value to list to keep track of rate class values
                           rateClassValues.Add(rateClassValue);
                       }
                       else if (rateClassValues.Contains(rateClassValue))
                       {
                           // delete duplicate itemGrp from parent
                           XmlNode parent = ch.ParentNode;
                           parent.RemoveChild(ch);
                       }
                   }
                }
    
                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "xmlNew.txt");
