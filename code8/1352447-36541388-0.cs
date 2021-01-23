    using System.Collections.Generic;
    public class Foo {
        public string Name { get; set; }
        public double Value { get; set; }
        public override string ToString() {
            return Name;
        }
        public override int GetHashCode() {
            return Name.GetHashCode();
        }
        public override bool Equals(object obj) {
            Foo other = obj as Foo;
            if (other == null) {
                return false;
            }
            return Name.Equals(other.Name);
        }
    }
    class Program {
        static void Main(string[] args) {
            Foo foo1 = new Foo { Name = "Foo1", Value = 2.2 };
            Foo foo2 = new Foo { Name = "Foo2", Value = 3.6 };
            Dictionary<Foo, int> dic = new Dictionary<Foo, int>();
            dic.Add(foo1, 1234);
            dic.Add(foo2, 2345);
            int i = dic[new Foo { Name = "Foo1" }];
        }
    }
