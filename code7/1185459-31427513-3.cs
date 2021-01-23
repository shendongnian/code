    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int> { 1, 872, -7, 271 ,-3, 7123, -721, -67, 68 ,15 };
    
            IEnumerable<A> result = data
                .GroupBy(key => Math.Sign(key))
                .Select((item, index) => new A { groupCount = item.Count(), str = item.Where(i => Math.Sign(i) > 0).Count() == 0 ? "negative" : "positive" });
    
            foreach(A a in result)
            {
                Console.WriteLine(a);
            }
        }
    }
    
    public class A
    {
        public int groupCount;
        public string str;
    
        public override string ToString()
        {
            return string.Format("Group Count: [{0}], String: [{1}].", groupCount, str);
        }
    }
