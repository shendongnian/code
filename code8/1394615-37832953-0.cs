    using System;
    
    namespace OverwriteValuesInMemory
    {
        class Program
        {
            static void Main()
            {
                // Ensure we have it on the heap
                var program = new Program();
                program.FillAndRefill();
                Console.WriteLine("Create a dump now");
                Console.ReadLine();
                // Access to prevent it from being optimized away
                program.nonboxed[0]=0;
            }
    
            const int M16 = 16 * 1024 * 1024;
            byte[] nonboxed = new byte[M16];
            object[] boxed = new object[M16];
    
            void FillAndRefill()
            { 
                Fill(nonboxed, 42);
                Fill(boxed, 23);
                Fill(nonboxed, 0x42);
                Fill(boxed, 0x23);
            }
    
            private void Fill(object[] array, int value)
            {
                for (int i = 0; i < array.Length; ++i)
                    array[i] = value;
            }
    
            private void Fill(byte[] array, byte value)
            {
                for (int i = 0; i < array.Length; ++i)
                    array[i] = value;
            }
        }
    }
