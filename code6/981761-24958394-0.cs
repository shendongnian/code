    public class MainClass
    {
        public string Something;
        public SubClassA A;
        public SubClassB B;
        public MainClass()
        {
            A = new SubClassA(this);
            B = new SubClassB(this);
        }
    }
