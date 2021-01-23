    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            var buffer = new StringBuilder(256);
            if (GetLocaleInfo(2057, 6, buffer, buffer.Capacity) == 0) {
                throw new System.ComponentModel.Win32Exception();
            }
            Console.WriteLine(buffer.ToString());
            Console.ReadLine();
        }
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetLocaleInfo(int LCID, int LCType, StringBuilder buffer, int buflen);
    }
