            var obj = JObject.Parse(geoString);
            foreach (var fix in (from property in obj.Descendants().OfType<JProperty>()
                                 let newName = XmlConvert.EncodeLocalName(property.Name.Replace(" ", ""))
                                 where newName != property.Name
                                 select new { Old = property, New = new JProperty(newName, property.Value) })
                       .ToList())
            {
                fix.Old.Replace(fix.New);
            }
            var xmldoc = JsonConvert.DeserializeXmlNode(obj.ToString());
