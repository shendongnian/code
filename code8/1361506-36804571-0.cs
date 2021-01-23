    namespace SafeHandles
    {
        public class PrinterSafeHandle : global::Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
        {
            [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
            private static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);
    
            [DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
            private static extern bool ClosePrinter(IntPtr hPrinter);
            
            public PrinterSafeHandle(string PrinterName) : base(true)
            {
                if (!OpenPrinter(PrinterName, out this.handle, IntPtr.Zero))
                {
                    throw new System.ComponentModel.Win32Exception();
                }
            }
    
            protected override bool ReleaseHandle()
            {
                return ClosePrinter(this.handle);
            }
        }
    }
