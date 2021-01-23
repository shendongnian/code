        public static IEnumerable<string> XmlFragmentsToCSV(TextReader textReader)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlReader reader = XmlReader.Create(textReader, settings))
            {
                while (reader.Read())
                {   // Skip whitespace
                    if (reader.NodeType == XmlNodeType.Element) 
                    {
                        using (var subReader = reader.ReadSubtree())
                        {
                            var element = XElement.Load(subReader);
                            yield return string.Join(",", element.DescendantNodes().OfType<XText>().Select(n => n.Value.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToArray());
                        }
                    }
                }
            }
        }
