    public class Data
    {
        public string Name { get; set; }
        public string Identity { get; set; }
    }
    public class CustomerComparer : IComparer<Data>
    {
        private List<string> orderedLetters = new List<string>() { "C", "A", "S" };
        public int Compare(Data str1, Data str2)
        {
            return orderedLetters.IndexOf(str1.Identity) - orderedLetters.IndexOf(str2.Identity);
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
                var data = customSortedValues[i];
                Console.WriteLine("{0}: {1}={2}", i, data.Name, data.Identity);
            }
        }
    }
    //Output is:  
    //0: Name3=C
    //1: Name4=C
    //2: Name2=A
    //3: Name1=S
