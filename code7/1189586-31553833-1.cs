    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                float  input = 123.45F;
                byte[] array = new byte[4];
                WriteFloat(input, ref array, 0);
                float output = ReadFloat(array, 0);
            }
            static public void WriteFloat(float v, ref byte[] m_Buffer, int m_Offset)
            {
                BitConverter.GetBytes(v).CopyTo(m_Buffer, m_Offset);
            }
            static public float ReadFloat(byte[] m_Buffer, int m_Offset)
            {
                return BitConverter.ToSingle(m_Buffer, m_Offset);
            }
        }
    }
    ​
