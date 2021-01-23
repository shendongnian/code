    public class Thing {
        private string name;
    
        public Thing(string name) {
            this.name = name;
        }
        public Thing Other {
            get;
            set;
        }
    
        public override string ToString() {
            return this.name;
        }
    }
    
    var o = new Thing("Foo");
    o.Other = o;
    Debug.WriteLine(o.Other.Other.Other.Other.ToString()); // Could go on forever
