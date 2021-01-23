    class Program
        {
            static void Main(string[] args)
            {
                var testList = new List<Test>();
                testList. Add(new Test() { Field4 = false, Field1 = 19845623, Field3 = 1658006 });
                testList.Add(new Test() { Field4 = false, Field1 = 19845645, Field3 = 1658056 });
                testList.Add(new Test() { Field4 = false, Field1 = 19845665, Field3 = 1658045 });
                testList.Add(new Test() { Field4 = false, Field1 = 19845678, Field3 = 1658078 });
                testList.Add(new Test() { Field4 = false, Field1 = 19845698, Field3 = 1658098 });
    
    
    
                var test = testList.Where(x => x.Field4 == false).ToList();
                Console.WriteLine();
            }
    }
    internal class Test
        {
            public int Field1 { get; set; }
            public long Field3 { get; set; }
            public bool Field4 { get; set; }
        }
