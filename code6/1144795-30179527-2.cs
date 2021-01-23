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
                StreamReader reader = new StreamReader("filename");
                UInt16 chr = (UInt16)reader.Read();
                UInt16 word = 0;
                int shift = -1;
                while (shift == -1)
                {
                    word = (UInt16)((UInt16)(word << 8) | chr);
                    shift = TestSync(chr, word);
                }
                while ((chr = (UInt16)reader.Read()) >= 0)
                {
                    word = (UInt16)((UInt16)(word << 8) | chr);
                    byte newChar = (byte)((word >> shift) & 0xff);
                }
            }
            static int TestSync(UInt16 chr, UInt16 word)
            {
                int results = -1;
                if((UInt16)(word & 0xff) == 0x11) return 0;
                if((UInt16)(word & 0xff) == 0x22) return 1; 
                if((UInt16)(word & 0xff) == 0x44) return 2;
                if((UInt16)(word & 0xff) == 0x88) return 3;
                if((UInt16)(word & 0x1fe) == 0x110) return 4;
                if((UInt16)(word & 0x3fc) == 0x220) return 5;
                if((UInt16)(word & 0x7f8) == 0x440) return 6;
                if ((UInt16)(word & 0xff0) == 0x880) return 7;
                return results;
            }
        }
    }
    ​
