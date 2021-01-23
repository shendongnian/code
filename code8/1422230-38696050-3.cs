    public interface IBase
    {
        bool[] IsEnable { get; }
    }
    public interface IClass1 : IBase { }
    public interface IClass2 : IBase { }
    public class DB : IBase
    {
        public bool[] IsEnable { get; set; }
    }
    public abstract class Base
    {
        public virtual void fRun(IBase p_oOb) { }
    }
    class MyClass1 : Base
    {
        public override void fRun(IBase p_oOb)
        {
            Console.WriteLine("MyClass1 fRun.");
        }
    }
    class MyClass2 : Base
    {
        public override void fRun(IBase p_oOb)
        {
            Console.WriteLine("MyClass2 fRun.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB();
            Base[] classes = new Base[] { new MyClass1(), new MyClass2() };
            foreach (var Class in classes)
            {
                Class.fRun(db);
            }
        }
    }
