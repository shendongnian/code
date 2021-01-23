    namespace MarhsalExampe
    {
        using System;
        using System.Runtime.InteropServices;
        public class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            public class SomeClass
            {
                public int IntProp { get; private set; }
                public string StrProp { get; private set; }
                public double DoubleProp { get; private set; }
                public bool BoolProp { get; private set; }
    
                public SomeClass() { }
                public SomeClass(int i, string s, double d, bool b)
                {
                    IntProp = i;
                    StrProp = s;
                    DoubleProp = d;
                    BoolProp = b;
                }
                public override string ToString()
                {
                    return string.Format("HashCode: {0}, IntProp: {1}, StrProp: {2}, DoubleProp: {3}, BoolProp: {4}",
                        GetHashCode(), IntProp, StrProp, DoubleProp, BoolProp);
                }
            }
            public static void Main()
            {
                var obj = new SomeClass(42, "42", 42.0, true);
                Console.WriteLine("Obj is: {0}", obj);
    
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    // Allocate memory in unmanaged memory
                    ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SomeClass)));
                    // Copy data to ptr
                    Marshal.StructureToPtr(obj, ptr, false);
                    Console.WriteLine("Pointer: 0x{0:X}", ptr.ToInt64());
    
                    // Create new object
                    var newObj = new SomeClass();
                    Console.WriteLine("newObj before updating from pointer: {0}", newObj);
                    // Copy data to new object
                    Marshal.PtrToStructure(ptr, newObj);
    
                    Console.WriteLine("newObj after updating: {0}", newObj);
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        Marshal.FreeHGlobal(ptr);
                }
            }
    
        }
    }
