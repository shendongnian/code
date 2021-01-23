        public static string ChangedPropertiesToXml<T>(T changedObj)
        {
            XmlDocument doc=new XmlDocument();
            XmlNode typeNode = doc.CreateNode(XmlNodeType.Element, typeof (T).Name, "");
            doc.AppendChild(typeNode);
            T templateObj = Activator.CreateInstance<T>();
            foreach (PropertyInfo info in
                typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (info.CanRead && info.CanWrite)
                {
                    object templateValue = info.GetValue(templateObj, null);
                    object changedValue = info.GetValue(changedObj, null);
                    if (templateValue != null && changedValue != null && !templateValue.Equals(changedValue))
                    {
                        XmlElement elem =  doc.CreateElement(info.Name);
                        elem.InnerText = changedValue.ToString();
                        typeNode.AppendChild(elem);
                    }
                }
            }
            StringWriter sw=new StringWriter();
            doc.WriteContentTo(new XmlTextWriter(sw));
            return sw.ToString();
        }
