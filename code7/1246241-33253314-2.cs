    using System.Runtime.InteropServices;
    using RGiesecke.DllExport;
    
    namespace ClassLibrary1
    {
        public class Class1
        {
            [DllExport]
            [return: MarshalAs(UnmanagedType.LPWStr)]
            public static string Concatenate(
                [MarshalAs(UnmanagedType.LPWStr)] string str1, 
                [MarshalAs(UnmanagedType.LPWStr)] string str2
            )
            {
                return str1 + str2;
            }
        }
    }
