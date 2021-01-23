    public abstract class A
    {
        public static int LastID = 0;
    
        public int ID { get; set; }
    
        public A()
        {
            this.ID = LastID - 1;
            LastID--;
        }
    }
    public class B : A 
    {
    
        public string Foo { get; set; }
    
        public B(string foo)
        {
            this.Foo = foo;
        }
    }
    
    B b1 = new B("foo");
    B b2 = new B("bar");
