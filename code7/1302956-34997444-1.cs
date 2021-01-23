    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication2
    {
        
        class Program
        {
            [DllImport("user32.dll")]
            public static extern Int32 GetSystemMetrics(Int32 bSwap);
    
            static void Main(string[] args)
            {
                //normally you would make this as a constant:
                int SM_SWAPBUTTON = 23;
    
                int isLeftHanded = GetSystemMetrics(SM_SWAPBUTTON);
                //0 means not swapped, 1 means swapped (left handedness?)
    
            }
        }
    }
