All StructureItem Elements: 8
someValue: 1001 localId: 0 globalId: 0
someValue: 1002 localId: 0 globalId: 1
someValue: 1003 localId: 1 globalId: 2
someValue: 1004 localId: 1 globalId: 3
someValue: 1005 localId: 2 globalId: 4
someValue: 1006 localId: 3 globalId: 5
someValue: 1007 localId: 2 globalId: 6
someValue: 1008 localId: 4 globalId: 7
TEST1 Elements: 5
someValue: 1001 localId: 0 globalId: 0
someValue: 1004 localId: 1 globalId: 3
someValue: 1005 localId: 2 globalId: 4
someValue: 1006 localId: 3 globalId: 5
someValue: 1008 localId: 4 globalId: 7
TEST2 Elements: 3
someValue: 1002 localId: 0 globalId: 1
someValue: 1003 localId: 1 globalId: 2
someValue: 1007 localId: 2 globalId: 6
The second workaround is using interfaces. This is usefull when you already inherit from some class and want to add static fields.
    public abstract class Class2 
    {
        public int someValue { get; set; }
    }
    public class TEST3 : Class2, ITest
    {
        public TEST3()
        {
            this.AddObj();
        }
     
    }
    public class TEST4 : Class2, ITest
    {
        public TEST4()
        {
            this.AddObj();
        }
    
    }
    public interface ITest{}
I used then a generic extension method for the interface
    public static class Class2Ex
    {
        public static void AddObj<T>(this T obj) where T : ITest
        {
            ITest<T>.Instances.Add(obj);
        }
        //Alternative:
        public static List<T> GetOtherInstances<T>(this T obj) where T : ITest
        {
            return ITest<T>.Instances;
        }
    }
    public static class ITest<T> where T : ITest
    {
        public static List<T> Instances = new List<T>();
    }
Example:
                TEST3 aTest1 = new TEST3();
                TEST3 aTest2 = new TEST3();
                TEST3 aTest3 = new TEST3();
                TEST3 aTest4 = new TEST3();
                TEST4 aTest5 = new TEST4();
                TEST4 aTest6 = new TEST4();
                Console.WriteLine("TEST4: " + ITest<TEST4>.Instances.Count);
                Console.WriteLine("TEST3: " + ITest<TEST3>.Instances.Count);
