    using System;
    using System.Runtime.InteropServices;
    class Libtest
    {
        [DllImport ("function")]
        private static extern int myfunc(int a);
        public static void Main()
        {
                int val = 1;
                Console.WriteLine(myfunc(val));
        }
    }
