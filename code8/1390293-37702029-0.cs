    public class test
    {
        public string waarde { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var teBeRemoved = new List<string> {"een", "twee"};
            var totalList = new List<test> { new test { waarde = "een" }, new test { waarde = "drie" } };
            var filteredList  = totalList.Where(i => !teBeRemoved.Contains(i.waarde));
        }
    }
