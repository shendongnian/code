    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            try {
                throw new IOException("test", unchecked((int)0x8007006d));
            }
            catch (IOException ex) {
                if (Marshal.GetHRForException(ex) != unchecked((int)0x8007006d)) throw;
            }
        }
    }
