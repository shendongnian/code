        private List<string[]> GetGroups(string xml)
        {
            List<string[]> result = new List<string[]>();
            XDocument document = XDocument.Parse(xml);
            XElement groups = document.Root;
            foreach (XElement group in groups.Elements("group"))
            {
                result.Add(group.Elements("member").Select(item => item.Attribute("name").ToString()).ToArray());
            }
            return result;
        }
