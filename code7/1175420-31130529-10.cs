	public static void Main()
	
        {
            IList<MyObject> list = new List<MyObject>();
            list.Add(new MyObject { P1 = "A", P2 = "B", P3 = "C", P4 = "D" });
            list.Add(new MyObject { P1 = "A", P2 = "A", P3 = "C", P4 = "D" });
            list.Add(new MyObject { P1 = "A", P2 = "A", P3 = "A", P4 = "D" });
            var testObject = new MyObject { P1 = "A", P2 = "A", P3 = "A", P4 = "A" };
           //create a list of annonymous class with inner MyObject and propertyMatches count, filter it by matches and return its inner MyObject
           //I think this query is easy to read, returs what you want (list of MyObject) in one line and can be applied without changes to any class as long implements propertyMatches.
            var res = from ao in (from obj in list select new { obj = obj, matches = obj.propertyMatches(testObject) }) where ao.matches >= 3 select ao.obj;
          //same query in method call form
          var res2 = list.Select(o => new
              {
                 matches = o.propertyMatches(testObject),
                 obj = o
              }).Where(ao => ao.matches >= 3).Select(ao => ao.obj);
            Console.WriteLine(res.First().P1);
            Console.WriteLine(res.First().P2);
            Console.WriteLine(res.First().P3);
            Console.WriteLine(res.First().P4);
            Console.WriteLine(res2.First().P1);
            Console.WriteLine(res2.First().P2);
            Console.WriteLine(res2.First().P3);
            Console.WriteLine(res2.First().P4);
        }
    }
     
