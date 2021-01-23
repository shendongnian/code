    using System;
    using System.Runtime.InteropServices;
    
    namespace CSharpLibraryNameSpace
    {   
        //Callback Interface declaration
        [ComVisible(true)]
        public interface CallbackInterface1
        {
            int InvokeUnmanaged(string strMsg);
        }
    
        [ComVisible(true)]
        public interface ManagedInterface
        {
            int Add(int Number1, int Number2);
            int CalltheCallbackFun(CallbackInterface1 callback);
        };
    
    
        // Interface implementation.
        [ComVisible(true)]
        public class ManagedCSharpClass : ManagedInterface
        {
            public int Add(int Number1, int Number2)
            {
                Console.Write("Inside MANAGED Add Num1={0} Num2={1}\n", Number1, Number2);
                return Number1 + Number2;
            }
    
            public int CalltheCallbackFun(CallbackInterface1 callback)
            {
                Console.Write("Inside MANAGED CalltheCallbackFun Before Call\n");
    
                int nRet = callback.InvokeUnmanaged("Message from C# :)");
    
                Console.Write("Inside MANAGED CalltheCallbackFun After Call Result={0}\n", nRet);
    
                return nRet;
            }
        }
    }
