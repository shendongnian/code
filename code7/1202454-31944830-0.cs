    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ulong results = 0;
                List<byte> output = null;
                List<byte> input1 = new List<byte>() { 1, 1, 0, 0, 0, 0, 0, 0 };
                results = ReadList(input1, 1);
                output = WriteList(results,1);
                List<byte> input2 = new List<byte>() { 0, 1, 0, 1, 0, 1, 0, 0 };
                results = ReadList(input2, 1);
                output = WriteList(results,1);
            }
            static ulong ReadList(List<byte> input, int size)
            {
                ulong results = 0;
                input.Reverse();
                MemoryStream stream = new MemoryStream(input.ToArray());
                BinaryReader reader = new BinaryReader(stream);
                while (reader.PeekChar() != -1)
                {
                    results = ((ulong)Math.Pow(2, size) * results) + (ulong)reader.ReadByte();
                }
                return results;
            }
            static List<byte> WriteList(ulong input, int size)
            {
                List<byte> results = new List<byte>();
                while (input > 0)
                {
                    byte bit = (byte)(input % Math.Pow(2, size));
                    results.Add(bit);
                    input = (ulong)(input / Math.Pow(2, size));
                }
                return results;
            }
        }
    }
    ​
