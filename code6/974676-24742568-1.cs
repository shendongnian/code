    void Main()
    {
        JsonConvert.SerializeObject(new Foo { Bar = new {
            num = 0
        },
        Baz = new { values = new[] { 0, 1, 2 } }
        }); // {"Bar":{"num":0},"Baz":{"values":[0,1,2]}}
    
    }
    class Foo {
        public object Bar { get; set; }
        public object Baz { get; set; }
    }
