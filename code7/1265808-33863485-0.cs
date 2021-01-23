    using System;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var value = 12288092688749907974u;
                var bytes = BitConverter.GetBytes(value);
    
                Console.Write(BitConverter.IsLittleEndian ? "IsLittleEndian Yes" : "IsLittleEndian No");
                Console.WriteLine(" Value " + BitConverter.ToString(bytes));
    
                Array.Reverse(bytes);
                Console.Write(BitConverter.IsLittleEndian ? "IsLittleEndian No" : "IsLittleEndian Yes");
                Console.WriteLine(" Value " + BitConverter.ToString(bytes));
    
                Console.Read();
            }
        }
    }
