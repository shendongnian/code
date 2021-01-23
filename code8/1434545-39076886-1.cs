            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(sw))
                {
                    xtw.Namespaces = false;
                    xtw.Formatting = Formatting.Indented;
                    xtw.WriteStartElement("log4j:event");
                    xtw.WriteAttributeString("logger", "MyTools");
                    xtw.WriteAttributeString("level", "WARN");
                    xtw.WriteAttributeString("timestamp", "763");
                    xtw.WriteElementString("log4j:message", "This is a log message.");
                    xtw.WriteEndElement();
                }
                string result = sw.ToString();
                Console.WriteLine(result);
            }
