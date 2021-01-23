    class Program
    {
        static void Main(string[] args)
        {
            var array = Class1.Sort();
            PrintArray(array);
    
            Console.WriteLine();
    
            Console.WriteLine("Total sum: {0}", Class1.TotalSum());
    
            Console.ReadLine();
        }
    
        static void PrintArray(List<double> array)
        {
            foreach (var a in array)
                Console.WriteLine(a);
        }
    }
    
    public class Class1
    {
    
        public static double TotalSum()
        {
            var rand = new Random();
    
            var alist = new List<double>();
            for (int i = 0; i < 50; i++)
            {
                alist.Add(rand.Next(10));
            }
    
            return alist.Sum();
        }
    
        public static List<double> Sort()
        {
            var rand = new Random();
    
            var slist = new List<double>();
            for (int i = 0; i < 50; i++)
            {
                slist.Add(rand.Next(10)); // rand.Next does not work with Sort
            }
    
            slist.Sort();
    
            return slist;
        }
    }
