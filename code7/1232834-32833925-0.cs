    public class Foo{
        public string propertyA;
        public string propertyB;
        public string propertyC;
        public List<string> list;
        Public Foo(string propA, string propB, string propC){
             propertyA = propA;
             propertyB = propB;
             propertyC = propC;
             list = new List<string>();
             list.Add(propertyA);
             list.Add(propertyB);
             list.Add(propertyC);
        }
    }
