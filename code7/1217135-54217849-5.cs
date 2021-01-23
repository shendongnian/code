    public class TEST1 : TESTAbstract<TEST1>
    {
        public TEST1(int i)
            : base()
        {
            this.someValue = i;
        }
    }
    public class TEST2 : TESTAbstract<TEST2>
    {
        public TEST2(int i)
            : base()
        {
            this.someValue = i;
        }
    }
