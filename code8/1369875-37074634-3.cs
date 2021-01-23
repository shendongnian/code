    using System;
    using System.Runtime.InteropServices;
    
    namespace CSharpLibraryNameSpace
    {    
        // Any delegate decorated as for PInoke
        public delegate int NativeDelegateType([MarshalAs(UnmanagedType.LPWStr)] string strMsg);
    
        // Interface declaration.
        [ComVisible(true)]
        public interface ManagedInterface
        {
            int Add(int Number1, int Number2);
    
            int CalltheCallbackFun(IntPtr callbackFnPtr);
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
    
            public int CalltheCallbackFun(IntPtr callbackFnPtr)
            {
                Console.Write("Inside MANAGED CalltheCallbackFun Before Call ptr={0}\n", callbackFnPtr);
    
                //Convert IntPtr to Delegate
                NativeDelegateType callback =
                    Marshal.GetDelegateForFunctionPointer(callbackFnPtr,
                        typeof(NativeDelegateType)) as NativeDelegateType;
    
                int nRet = callback("Message from C# :)");
    
                Console.Write("Inside MANAGED CalltheCallbackFun After Call Result={0}\n", nRet);
    
                return nRet;
            }
        }
    }
