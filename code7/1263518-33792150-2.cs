    public class Program
    {   
        public static void Main() 
        {
            Console.WriteLine("foo");
        }
        private static readonly Lazy<List<int>> _list = new Lazy<List<int>>(() => InitList());
        private static List<int> InitList()
        {
            var list = new List<int>() { 1,2,3 };
            list.AsParallel().WithDegreeOfParallelism(4).ForAll(item => { Console.WriteLine(item.ToString()); });
            return list;
        }
    }
