    public class Program
    {
        static FilterDelegate mdel;
        public static void Main(string[] args)
        {
            FilterDelegate del = new FilterDelegate(Win32Handler);
            SetUnhandledExceptionFilter(del);
            GC.KeepAlive(del);  // do not collect "del" in this scope (main)
            // You could also use mdel, which I dont believe is collected either
            GC.Collect();
            native_crash_on_unmanaged_thread(); 
        }
    }
