    public class Data
    {
        public string Name { get; set; }
        public string Identity { get; set; }
    }
    public class CustomerComparer : IComparer<KeyValuePair<int, Data>>
    {
        private List<string> orderedLetters = new List<string>() { "C", "A", "S" };
        public int Compare(KeyValuePair<int, Data> str1, KeyValuePair<int, Data> str2)
        {
            return orderedLetters.IndexOf(str1.Value.Identity) - orderedLetters.IndexOf(str2.Value.Identity);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Data value1 = new Data { Name = "Name1", Identity = "S" };
            Data value2 = new Data { Name = "Name2", Identity = "A" };
            Data value3 = new Data { Name = "Name3", Identity = "C" };
            Data value4 = new Data { Name = "Name4", Identity = "C" };
            Dictionary<int, Data> unsortedDictionary = new Dictionary<int, Data>();
            unsortedDictionary.Add(1, value1);
            unsortedDictionary.Add(2, value2);
            unsortedDictionary.Add(3, value3);
            unsortedDictionary.Add(4, value4);
            var customSortedValues = unsortedDictionary.Values.OrderBy(item => item, new CustomerComparer()).ToArray();
            for (int i=0; i < customSortedValues.Length; i++)
            {
                var kvp = customSortedValues[i];
                Console.WriteLine("{0}: {1}=(Name={2}, Identity={3})", i, kvp.Key, kvp.Value.Name, kvp.Value.Identity);
            }
        }
    }
    //Output is:  
    //0: Name3=C
    //1: Name4=C
    //2: Name2=A
    //3: Name1=S
