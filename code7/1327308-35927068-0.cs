    public class ClassB
    {
        ClassA A;
        public int AID { get {return A.ID;} }
        public ClassB(ClassA a)
        {
            A = a;
        }
    }
