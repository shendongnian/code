        class Program
        {
            static void Main(string[] args)
            {
     
               Dictionary<int, string> file1Dictionary = new Dictionary<int, string>();
               Dictionary<int, string> file2Dictionary = new Dictionary<int, string>();
               //Fill dictionaries with data from flat files
               //...
               Dictionary<string, List<int>> reverseDict1 = file1Dictionary.Keys.AsEnumerable()
                   .Select(x => new { value = x, keys = file1Dictionary[x] })
                   .GroupBy(x => x.keys, y => y.value)
                   .ToDictionary(x => x.Key, y => y.ToList());
               Dictionary<string, List<int>> reverseDict2 = file1Dictionary.Keys.AsEnumerable()
                   .Select(x => new { value = x, keys = file2Dictionary[x] })
                   .GroupBy(x => x.keys, y => y.value)
                   .ToDictionary(x => x.Key, y => y.ToList());
               Dictionary<string, MatchedPairs> matches = new Dictionary<string, MatchedPairs>();
               foreach(string key in reverseDict1.Keys)
               {
                   matches.Add(key, new MatchedPairs(reverseDict1[key], reverseDict2[key]));
               }
     
            }
        }
        public class MatchedPairs
        {
            public List<int> index1 { get; set; }
            public List<int> index2 { get; set; }
            public MatchedPairs(List<int> l1, List<int> l2)
            {
                this.index1 = new List<int>(l1);
                this.index2 = new List<int>(l2);
            }
        }
