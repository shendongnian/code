    using System;
    using System.Runtime.InteropServices;
    
    namespace ShellMe
    {
        class MainClass
        {
            [DllImport ("libc")]
            private static extern int system (string exec);
    
            public static void Main (string[] args)
            {
                system("YourCommand2Run");   // blocking, you are in a shell so same rules apply
                system("YourCommand2Run &"); // non-blocking
            }
        }
    }
