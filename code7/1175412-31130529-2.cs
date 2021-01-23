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
    
    //create a list of annonymous class with inner MyObject and propertyMatches count, filter it by matches and return its inner MyObject
    //I think this query is easy to read and returs what you want (list of MyObject) in one line.
    var res = (from obj in list select new { obj = obj, matches = obj.propertyMatches(testObject) }).Where(annonymousObject => annonymousObject.matches >= 3).Select(annonymousObject => annonymousObject.obj);
    
                Console.WriteLine(res2.First().P1);
                Console.WriteLine(res2.First().P2);
                Console.WriteLine(res2.First().P3);
                Console.WriteLine(res2.First().P4);
                Console.Read();
            }
        }
