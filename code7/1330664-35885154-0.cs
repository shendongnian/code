    public class Test
    {
        public int foo;
        public int bar;
    }
    public static void Main()
    {
        //important, filters can not repeated!
        var filters = new List<Test> {
            new Test { foo = 2, bar = 4 },
            new Test { foo = 5, bar = 7 },
            new Test { foo = 9, bar = 10 },
            new Test { foo = 11, bar = 12 }
        };
        //I mocked context only for demonstration purposes
        var myClass = new List<Test> {
            new Test { foo = 5, bar = 7 },
            new Test { foo = 9, bar = 10 }
        };
        var query = (from filter in filters
                    join data in myClass on new { filter.bar, filter.foo } equals new { data.bar, data.foo }
                    select data).ToList();
    } 
