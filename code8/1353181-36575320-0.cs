     public class Test1
     {
        public delegate void HandleErrorGenerated(Exception exc, string method);
        public event HandleErrorGenerated ExceptionGenerated;
        private void OnExceptionGenerated(Exception exc, string method)
        {
            if (ExceptionGenerated != null)
            {
                ExceptionGenerated(exc, method);
            }
            else
            {
                throw exc;
            }
        }
        private void MethodInMyThread()
        {
             try
             {
             //do stuff
             }
             catch(Exception e)
             {
                 OnExceptionGenerated(e, "MethodInMyThread");
             }
        }
     }
     public class Form1
     {
         Test1 theTest = new Test1();
         public Form1()
         {
             Test1.ExceptionGenerated += test1_ExceptionGenerated;
         }
         private void test1_ExceptionGenerated(Exception exc, string method)
         {
              //handle variable passed
         }
     }
