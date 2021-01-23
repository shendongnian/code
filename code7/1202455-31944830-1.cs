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
                List<ulong> results = null;
                List<byte> output = null;
                List<byte> input1 = new List<byte>() { 1, 1, 0, 0, 0, 0, 0, 0 };
                results = ReadList(input1, 1);
                output = WriteList(results,1);
                List<byte> input2 = new List<byte>() { 0, 1, 0, 1, 0, 1, 0, 0 };
                results = ReadList(input2, 1);
                output = WriteList(results,1);
            }
            static List<ulong> ReadList(List<byte> input, int size)
            {
                List<ulong> results = new List<ulong>();
                input.Reverse();
                MemoryStream stream = new MemoryStream(input.ToArray());
                BinaryReader reader = new BinaryReader(stream);
                int count = 0;
                ulong newValue = 0;
                while (reader.PeekChar() != -1)
                {
                  
                    switch (size)
                    {
                        case 1:
                            newValue = ((ulong)Math.Pow(2, size) * newValue) + (ulong)reader.ReadByte();
                            break;
                        case 2:
                            newValue = ((ulong)Math.Pow(2, size) * newValue) + (ulong)reader.ReadInt16();
                            break;
                    }
                    if (++count == size)
                    {
                        results.Add(newValue);
                        newValue = 0;
                        count = 0;
                    }
                }
                return results;
            }
            static List<byte> WriteList(List<ulong> input, int size)
            {
                List<byte> results = new List<byte>();
                foreach (ulong num in input)
                {
                    ulong result = num;
                    for (int count = 0; count < size; count++)
                    {
                        if (result > 0)
                        {
                            byte bit = (byte)(result % Math.Pow(2, size));
                            results.Add(bit);
                            result = (ulong)(result / Math.Pow(2, size));
                        }
                        else
                        {
                            results.Add(0);
                        }
                    }
                }
                results.Reverse();
                return results;
            }
        }
    }
    ​
