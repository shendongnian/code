    public class BaseClass
    {
        public string BaseClassFoo { get; set; }
    }
    public class ClassA : BaseClass
    {
        public string ClassAFoo { get; set; }
    }
    public class ClassB : BaseClass
    {
        public string ClassBFoo { get; set; }
    }
    public interface IMyList {
        void CommonOperation();
    }
    public class ListA : List<ClassA>, IMyList
    {
        public void CommonOperation() {
            Console.WriteLine(this[0].ClassAFoo);
        }
    }
    public class ListB : List<ClassB>, IMyList
    {
        //
        public void CommonOperation() {
            Console.WriteLine(this[0].ClassBFoo);
        }
    }
    
    class Program {
        private static void Main(string[] args) {
            IMyList a = new ListA { new ClassA { ClassAFoo = "I'm an A" } };
            IMyList b = new ListB { new ClassB { ClassBFoo = "I'm a B" } };
            a.CommonOperation();
            b.CommonOperation();
        }
    }
