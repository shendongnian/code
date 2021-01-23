    // Interface declaration.
    // Any delegate decorated as for PInoke
    public delegate int NativeDelegateType(int x);
    
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
            Console.Write("Add\n");
            return Number1 + Number2;
        }
    
        public int CalltheCallbackFun(IntPtr callbackFnPtr)
        {
            Console.Write("BB\n");
            string str;
            str = "AAA";
            unsafe
            {
                fixed (char* p = str)
                {
                    Console.Write("before call callbackFun ptr={0}\n", callbackFnPtr);
                    //Convert IntPtr to Delegate
                    var callback = 
                        Marshal.GetDelegateForFunctionPointer(callbackFnPtr,
                                                 typeof(NativeDelegateType))
                        as NativeDelegateType;
                    callback(45);
                }
            }
            return 0;
        }
    }
