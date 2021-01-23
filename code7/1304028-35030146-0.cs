    public class A
    {
        public B SetBProperty 
        { 
            get { return B.BString; } 
            set { B.BString = value; } 
        }
        public class B {
            public static string BString = null;
        }
    }
