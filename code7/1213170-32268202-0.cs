            XElement rootElement = XElement.Parse(stringXml);
            if (rootElement.Attribute("documentID").Value == "CSTrlsEN")
            {
                 var colNames = from field in rootElement.Elements("field")
                              where Convert.ToInt32(field.Attribute("pos").Value) >= 5
                              select field.Attribute("name").Value;
                 foreach (var name in colNames)
                 {
                     Console.WriteLine(name);
                 }
            }
