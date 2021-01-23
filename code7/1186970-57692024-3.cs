    public abstract class Test
    {
        public string Name;
        public Test(string s)
        {
            Name = s;
        }
    }
    public class T1 : Test
    {
        public T1() : base("T1")
        {
        }
    }
    public class T2 : Test
    {
        public T2() : base("T2")
        {
        }
    }
