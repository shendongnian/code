    Encoding enc = (Encoding)Encoding.GetEncoding("iso-2022-jp").Clone();
    enc.EncoderFallback = new EncoderReplacementFallback("");
    byte[] bytes = new byte[16];
    using (StreamWriter sw = new StreamWriter(@"C:\temp\iso-2022-jp.txt"))
    {
        int max = -1;
        for (int i = 0; i <= 0x10FFFF; i++)
        {
            if (i >= 0xD800 && i <= 0xDFFF)
            {
                continue;
            }
            string chars = char.ConvertFromUtf32(i);
            int count = enc.GetBytes(chars, 0, chars.Length, bytes, 0);
            if (count != 0)
            {
                sw.WriteLine(chars);
                max = i;
            }
        }
        Console.WriteLine("maximum codepoint: {0}", max);
    }
