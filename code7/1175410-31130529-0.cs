    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                IList<MyObject> list = new List<MyObject>();
    
                list.Add(new MyObject { P1 = "A", P2 = "B", P3 = "C", P4 = "D" });
                list.Add(new MyObject { P1 = "A", P2 = "A", P3 = "C", P4 = "D" });
                list.Add(new MyObject { P1 = "A", P2 = "A", P3 = "A", P4 = "D" });
    
                var testObject = new MyObject { P1 = "A", P2 = "A", P3 = "A", P4 = "A" };
    
                var res = from o in list let pm = o.propertyMatches(testObject) select new { obj = o, matches = pm };
                var res2 = from r in res where r.matches == res.Max(r2 => r2.matches) select r.obj;
    
                Console.WriteLine(res2.First().P1);
                Console.WriteLine(res2.First().P2);
                Console.WriteLine(res2.First().P3);
                Console.WriteLine(res2.First().P4);
                Console.Read();
            }
        }
