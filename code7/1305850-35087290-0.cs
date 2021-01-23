    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();
            a.Prop = new MyBase();
            Console.WriteLine("'{0}'", a.Prop); // 'classtest.MyBase'
            Console.WriteLine("'{0}'", ((B)a).Prop); // ''
            a.Prop = new Final();
            Console.WriteLine("'{0}'", a.Prop); // 'classtest.Final'
            Console.WriteLine("'{0}'", ((B)a).Prop); // 'classtest.Final'
        }
    }
    public class MyBase
    {
    }
    public class Final : MyBase
    {
    }
    public class A
    {
        public MyBase Prop { get; set; }
    }
    public class B : A
    {
        public new Final Prop
        {
            get { return base.Prop as Final; }
            set { base.Prop = value; }
        }
    }
