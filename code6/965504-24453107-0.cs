    namespace test
    {
       public class A
       {
           public int n { get; set; }
           public int NumbMethod(int Number)
           {
                int n = Number;
                console.writeline(n);
           }
        }
    }
    class MyClass
    {
        public static int Main()
        {
            test mytest = new test();   
            Type myTypeObj = mytest.GetType();    
            MethodInfo myMethodInfo = myTypeObj.GetMethod("NumbMethod");
            object[] parmint = new object[] {5};
            myMethodInfo.Invoke(myClassObj, parmint);
        }
     }
