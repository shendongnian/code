    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint SearchPath(string lpPath,
             string lpFileName,
             string lpExtension,
             int nBufferLength,
             [MarshalAs ( UnmanagedType.LPTStr )]
                 StringBuilder lpBuffer,
             out IntPtr lpFilePart);
        const int MAX_PATH = 260;
        public static void Main()
        {
            StringBuilder sb = new StringBuilder(MAX_PATH);
            IntPtr discard;
            var nn = SearchPath(null, "notepad.exe", null, sb.Capacity, sb, out discard);
            if (nn == 0)
            {
                var error = Marshal.GetLastWin32Error();
                // ERROR_FILE_NOT_FOUND = 2
                if (error == 2) Console.WriteLine("No file found.");
                else
                    throw new System.ComponentModel.Win32Exception(error);
            }
            else
                Console.WriteLine(sb.ToString());
        }
    }
