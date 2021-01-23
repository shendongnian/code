    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = {4,1,5,4,3,1,6,5};
            var query = ints.GroupBy(x => x).OrderBy(x => x.Count()).Select(x => x);
           
            // print ordered array showing dupes are last
            query.ToList().ForEach(x => Console.WriteLine(x.Key.ToString()));
            
            // Get number of dupes
            int dupeCount = query.Where(x => x.Count() > 1).Count();
            // put unique items into a new array
            var newArray = query.Where(x => x.Count() == 1).Select(x => x.Key).ToArray();
            
            // put distinct items into an array
            var distinctArray = ints.Distinct().ToArray();
            Console.ReadKey();   
        }
    }
