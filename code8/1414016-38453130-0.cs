    public  class A
    {
        public virtual void Food()
        {
            Console.Write("1");
        }
    }
    public class B : A
    {
        public override void Food()
        {
            Console.Write("2");
        }
    }
