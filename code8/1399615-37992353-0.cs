    public class TestClass
    {
        private Dictionary<string, List<string>> sequences;
        
        public TestClass()
        {
            sequences = new Dictionary<string, List<string>>();
            sequences.Add("Phe", new List<string>() {"TTT", "TTC"});
            // Repeat for all the sequences.
        }
    
        public string GetSequenceType(string sequence)
        {
            foreach (var key in sequences.Keys)
            {
                if (sequences[key].Contains(sequence)
                    return key;
            }
            return null;
        }
    }
