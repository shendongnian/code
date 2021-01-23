    public class RegKey
        {
            public string Name { get; set; }
            public List<CEKeys> Key = new List<CEKeys>();
            Dictionary<string, List<CEKeys>> dictionary = new Dictionary<string, List<CEKeys>>();
            public RegKey()
            {
                Key = new List<CEKeys>();
               
                dictionary.Add(Name, Key);
            }
            
        }
