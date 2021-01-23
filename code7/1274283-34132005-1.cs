    public class SomeClass
    {
        private object obj;
        public void func1()
        {    
            try
            {
                 obj=new object();
                 // implied more code here
            }
            finally
            {
                 obj = null;
            }
        }
    }
