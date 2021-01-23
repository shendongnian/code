    public class MainClass
    {
        private MyType myType = null;
        private string myParm = string.Empty;
    
        private MainClass()
        {
        }
    
        public MainClass(string inParm)
            : this()
        {
            myType = new MyType();
            myParm = inParm;
        }
    }
