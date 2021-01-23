    public class MainClass
    {
        private MyType myType = null;
        private string myParm = string.Empty;
    
        private MainClass()
        {
            myType = new MyType();
        }
    
        public MainClass(string inParm)
            : this()
        {
            myParm = inParm;
        }
    }
