        public class Proxy
        {
            public object obj { get; set; }
            public DateTime date { get; set; }
        }
        var listAll = listA.Select(a => new Proxy { obj = a, date = a.date }).Union(listB.Select(b => new Proxy { obj = b, date = b.date })).OrderBy(d=>d.date).ToList();
        listAll.ForEach(c => 
           {
                if (c.obj.GetType() == typeof(A))
                    printA(((A)c.obj));
                else if (c.obj.GetType() == typeof(B))
                    printB(((B)c.obj));
           }
