    public class Foo {
    
        private List<Bar> names;
        private string name;
    
        public Foo() {
            this.name = "Name";
            this.names = new List<Bar>() {
                new Bar("a"),
                new Bar("b"),
                new Bar("c")
            };
        }
    
        public string Name {
            get {
                return this.name;
            }
        }
    
        public List<Bar> Names {
            get {
                return this.names;
            }
        }
    }
    
    public class Bar {
        public Bar(string name) {
            this.Name = name;
        }
    
        public string Name {
            get;
            private set;
        }
    }
    var o = new Foo();
    Debug.WriteLine(JsonConvert.SerializeObject(o));
