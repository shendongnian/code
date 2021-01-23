    public class ClassA
    {
        public int ID;
        public ClassA(int id)
        {
            ID = id;
        }
    }
    public class ClassB
    {
        public ClassA A;
        public ClassB(ClassA a)
        {
            A = a;
        }
    }
    public class TestMain
    {
        static void Main(string[] args)
        {
            ClassA a = new ClassA(1);
            ClassB b = new ClassB(a);
            a.ID = 3;
            Console.WriteLine(b.A.ID); //prints 3
            Console.ReadLine();
        }
    }
