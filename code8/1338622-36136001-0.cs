    public class A : Base
    {
        public string Str2;
        public A(string str2)
            : this(str2, str2)
        {
        }
        public A(string str2, string str)
            : base(str)
        {
            Str2 = str2;
        }
    }
