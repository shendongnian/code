    namespace ValueEquality
    {
        class MyClass : IEquatable<MyClass>
        {
            public int ImportantProperty1 { get; set; }
            public int ImportantProperty2 { get; set; }
            public int ImportantProperty3 { get; set; }
            public int ImportantProperty4 { get; set; }
            public int NonImportantProperty { get; set; }
            public bool Equals(MyClass other)
            {
                if (Object.ReferenceEquals(this, other))
                    return true;    
                return
                    (!Object.ReferenceEquals(this, null)) &&
                    (this.ImportantProperty1 == other.ImportantProperty1) &&
                    (this.ImportantProperty2 == other.ImportantProperty2) &&
                    (this.ImportantProperty3 == other.ImportantProperty3) &&
                    (this.ImportantProperty4 == other.ImportantProperty4);
            }
            public override bool Equals(object obj)
            {
                return this.Equals(obj as MyClass);
            }
            public override int GetHashCode()
            {
                unchecked {
                    int hash = 17;
                    hash = hash * 23 + ImportantProperty1.GetHashCode();
                    hash = hash * 23 + ImportantProperty2.GetHashCode();
                    hash = hash * 23 + ImportantProperty3.GetHashCode();
                    hash = hash * 23 + ImportantProperty4.GetHashCode();
                    return hash;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyClass a = new MyClass() { };
                MyClass b = new MyClass() { };
                if (a.Equals(b))
                    Console.WriteLine("a and b are equal");
            }
        }
    }
