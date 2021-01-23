    using RGiesecke.DllExport;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ClassLibrary1
    {
        internal static class Class1
        {
            [DllExport("square", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            static Double Square(Double dateValue)
            {
                return dateValue * dateValue;
            }
    
            [DllExport("test", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            static String Test()
            {
                return " ok";
            }
    
            [DllExport("mytest2", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            static void Test4(String doSomething)
            {
                // Manipulate (and obisously create new) String
                doSomething += " ok";
            }
        }
    }
