    void Main()
    {
        Console.WriteLine(JsonConvert.SerializeObject(new Foo { Bar = new Bar {
            num = 0
        },
        Baz = new Baz { values = new[] { 0, 1, 2 } }
        })); // {"Bar":{"num":0},"Baz":{"values":[0,1,2]}}
    
    }
    public class Foo {
        public Bar Bar { get; set; }
        public Baz Baz { get; set; }
    }
    public class Bar {
        public int num { get; set; }
    }
    public class Baz {
        public int[] values { get; set; }
    }
