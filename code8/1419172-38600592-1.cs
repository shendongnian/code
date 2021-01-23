        static void Main(string[] args)
        {
            List<MyClass> list1 = new List<MyClass>();
            
            MyClass myClass1 = new MyClass() {Id = 1};
            MyClass myClass2 = new MyClass() {Id = 2};
            list1.Add(myClass1);
            list1.Add(myClass2);
            List<MyClass> list2 = new List<MyClass>();
            list2.Add(myClass1);
            var exceptList = list1.Except(list2);
            foreach (var myClass in exceptList)
            {
                Console.WriteLine(myClass.Id);
            }
        }
        public class MyClass : IEquatable<MyClass>
        {
            public int Id { get; set; }
             
            public bool Equals(MyClass other)
            {
                return Id == other.Id;
            }
            public override int GetHashCode()
            {
                return Id;
            }
        }
