    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        public unsafe struct MyStruct
        {
            private const int floatArrayLength = 4;
    
            private fixed float _floatArray[floatArrayLength];
    
            public float[] floatArray
            {
                get
                {
                    float[] result = new float[floatArrayLength];
                    fixed (float* ptr = _floatArray)
                    {
                        Marshal.Copy((IntPtr)ptr, result, 0, floatArrayLength);
                    }
                    return result;
                }
                set
                {
                    int length = Math.Min(floatArrayLength, value.Length);
                    fixed (float* ptr = _floatArray)
                    {
                        Marshal.Copy(value, 0, (IntPtr)ptr, length);
                        for (int i = length; i < floatArrayLength; i++)
                            ptr[i] = 0;
                    }
                }
            }
        }
        
        class Program
        {
            static void WriteArray(float[] arr)
            {
                foreach (float value in arr)
                {
                    Console.Write(value);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
    
            static void Main(string[] args)
            {
                MyStruct myStruct = new MyStruct();
                WriteArray(myStruct.floatArray);
                myStruct.floatArray = new float[] { 1, 2, 3, 4 };
                WriteArray(myStruct.floatArray);
                myStruct.floatArray = new float[] { 5, 6 };
                WriteArray(myStruct.floatArray);
                Console.ReadLine();
            }
        }
    }
