    public class ComputationProject
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void FunctionPointer([MarshalAs(UnmanagedType.LPStr)]string message);
    
            public readonly FunctionPointer DisplayMethod;
            
            public ComputationProject(IntPtr ptr)
            {
                this.DisplayMethod = (FunctionPointer)Marshal.GetDelegateForFunctionPointer(ptr, typeof(FunctionPointer));                       
            }
    
            public int Compute()
            {            
                this.DisplayMethod("Beginning computation...");
                ...
            }
        }
