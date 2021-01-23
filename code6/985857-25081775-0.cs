    using System;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        [StructLayout(LayoutKind.Explicit)]
        struct Color
        {
            [FieldOffset(0)]
            public uint value;
            [FieldOffset(0)]
            public byte R;
            [FieldOffset(1)]
            public byte G;
            [FieldOffset(2)]
            public byte B;
            [FieldOffset(3)]
            public byte A;
            static public implicit operator uint(Color c)
            {
                return c.value;
            }
        }
        class Program
        {
            static unsafe void Main(string[] args)
            {
                Color[] colors = new Color[] { new Color { R = 255 }, new Color { B = 255 } };
                Console.WriteLine(colors[0]);
                Console.WriteLine(colors[1]);
                fixed (Color* thisPtr = &colors[0])
                {
                    ((uint*)thisPtr)[0] = 2;
                    ((uint*)thisPtr)[1] = 4;
                    Console.WriteLine(colors[0]);
                    Console.WriteLine(colors[1]);
                }
                Console.ReadKey();
            }
        }
    }
