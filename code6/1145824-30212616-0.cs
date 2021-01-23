    public class ConnectionRenumberer
    {
        private List<string> phraseIds;
    
        public string RenumberConnections(string xml)
        {
            phraseIds = new List<string>();
    
            var doc = XDocument.Parse(xml);
    
            foreach (var connection in doc.Descendants("Connection"))
            {
                var from = connection.Attribute("From_PhraseID");
                from.Value = NewPhraseId(from.Value);
                        
                var to = connection.Attribute("To_PhraseID");
                to.Value = NewPhraseId(to.Value);                    
            }
    
            return doc.ToString();
        }
    
        private string NewPhraseId(string value)
        {
            var index = phraseIds.IndexOf(value);
    
            if (index == -1)
            {
                index = phraseIds.Count;
                phraseIds.Add(value);
            }
    
            return index.ToString();
        }
    }
