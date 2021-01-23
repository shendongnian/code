    using System;
    using System.Reflection.Emit;
    class Program
    {
        static void Main()
        {
            DynamicMethod method =
                new DynamicMethod("ByteToBoolean", typeof(bool), new[] { typeof(byte) });
            ILGenerator il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0); // Load the byte argument...
            il.Emit(OpCodes.Ret);     // and "cast" it directly to bool.
            var byteToBoolean =
                (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            bool x = true;
            bool y = byteToBoolean(2);
            Console.WriteLine(x);               // True
            Console.WriteLine(y);               // True
            Console.WriteLine(x && y);          // True
            Console.WriteLine(x & y);           // False (!) because 1 & 2 == 0
            Console.WriteLine(y.Equals(false)); // False
            Console.WriteLine(y.Equals(true));  // False (!) because 2 != 1
        }
    }
