    public class Test
    {
        public int foo;
        public int bar;
    }
    public static void Main()
    {
        var filters = new List<Test> {
            new Test { foo = 2, bar = 4 },
            new Test { foo = 5, bar = 7 },
            new Test { foo = 9, bar = 10 },
            new Test { foo = 11, bar = 12 }
        };
        var newFilter = filters.Select(x => x.foo + "-" + x.bar).ToList();
        var answer = context.myClass.Where(x => newFilter.Contains(x.foo + "-" + x.bar)).ToList();
    } 
