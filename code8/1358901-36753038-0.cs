         XmlDocument xmlDoc = new XmlDocument();
         XmlElement xmlItem;
         XmlAttribute xmlAttr;
         XmlText xmlText;
         // Declaration
         XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
         XmlElement xmlRoot = xmlDoc.DocumentElement;
         xmlDoc.InsertBefore(xmlDec, xmlRoot);
         // Items
         XmlElement xmlItems = xmlDoc.CreateElement(string.Empty, "Items", string.Empty);
         xmlDoc.AppendChild(xmlItems);
         // Item #1
         xmlItem = xmlDoc.CreateElement(string.Empty, "item", string.Empty);
         xmlAttr = xmlDoc.CreateAttribute(string.Empty, "id", string.Empty);
         xmlAttr.Value = "&#8209;";
         xmlItem.Attributes.Append(xmlAttr);
         xmlAttr = xmlDoc.CreateAttribute(string.Empty, "replacewith", string.Empty);
         xmlAttr.Value = "-";
         xmlItem.Attributes.Append(xmlAttr);
         xmlText = xmlDoc.CreateTextNode("Non breaking hyphen");
         xmlItem.AppendChild(xmlText);
         xmlItems.AppendChild(xmlItem);
         // Item #2
         xmlItem = xmlDoc.CreateElement(string.Empty, "item", string.Empty);
         xmlAttr = xmlDoc.CreateAttribute(string.Empty, "id", string.Empty);
         xmlAttr.Value = " ";
         xmlItem.Attributes.Append(xmlAttr);
         xmlAttr = xmlDoc.CreateAttribute(string.Empty, "replacewith", string.Empty);
         xmlAttr.Value = "&nbsp;";
         xmlItem.Attributes.Append(xmlAttr);
         xmlText = xmlDoc.CreateTextNode("Non breaking hyphen");
         xmlItem.AppendChild(xmlText);
         xmlItems.AppendChild(xmlItem);
         // For formatting
         StringBuilder xmlBuilder = new StringBuilder();
         XmlWriterSettings xmlSettings = new XmlWriterSettings
         {
            Indent = true,
            IndentChars = "  ",
            NewLineChars = "\r\n",
            NewLineHandling = NewLineHandling.Replace
         };
         using (XmlWriter writer = XmlWriter.Create(xmlBuilder, xmlSettings))
         {
            xmlDoc.Save(writer);
         }
         xmlOutput.Text = xmlBuilder.ToString();
