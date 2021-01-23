    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.SqlServer.Server;
    using System.Data.SqlTypes;
    namespace Numeric2Comp3
    {
    //PackedDecimal conversions
    public class PackedDecimal
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void ToComp3(long value, out byte[] hexarray, out string hexvalue)
        {
            Stack<byte> comp3 = new Stack<byte>(10);
            byte currentByte;
            if (value < 0)
            {
                currentByte = 0x0d;
                value = -value;
            }
            else
            {
                currentByte = 0x0c;
            }
            bool byteComplete = false;
            while (value != 0)
            {
                if (byteComplete)
                    currentByte = (byte)(value % 10);
                else
                    currentByte |= (byte)((value % 10) << 4);
                value /= 10;
                byteComplete = !byteComplete;
                if (byteComplete)
                    comp3.Push(currentByte);
            }
            if (!byteComplete)
                comp3.Push(currentByte);
            hexarray = comp3.ToArray();
            hexvalue = bytesToHex(comp3.ToArray());
        }
        private static string bytesToHex(byte[] buf)
        {
            string HexChars = "0123456789ABCDEF";
            System.Text.StringBuilder sb = new System.Text.StringBuilder((buf.Length / 2) * 5 + 3);
            for (int i = 0; i < buf.Length; i++)
            {
                sbyte b = Convert.ToSByte(buf[i]);
                b = (sbyte)(b >> 4);     // Hit to bottom
                b = (sbyte)(b & 0x0F);   // get HI byte
                sb.Append(HexChars[b]);
                b = Convert.ToSByte(buf[i]);             // refresh
                b = (sbyte)(b & 0x0F);   // get LOW byte
                sb.Append(HexChars[b]);
            }
            return sb.ToString();
        } 
 
    } 
    }
