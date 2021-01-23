    using System;
    using System.Runtime.InteropServices;
    namespace callbacktest {
        class MainClass {
            [DllImport("/home/pax/addViaCallback.so",
                CallingConvention = CallingConvention.Cdecl)]
                public static extern int addViaCallback (IntPtr cb, int n1, int n2);
            public static int CallbackFn (int a, int b) {
                return a + b;
            }
            public delegate int AddViaCallbackDelegate (int a, int b);
            public static void Main (string[] args) {
                IntPtr addViaCallbackFp = Marshal.GetFunctionPointerForDelegate(
                    new AddViaCallbackDelegate (MainClass.CallbackFn));
                for (int a = 0; a < 5; a++) {
                    for (int b = 0; b < 5; b++) {
                        int c = addViaCallback (addViaCallbackFp, a, b);
                        Console.WriteLine (a + " + " + b + " = " + c);
                    }
                }
            }
        }
    }
