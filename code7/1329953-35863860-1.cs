    for (int i = 0; i < 65535; i++)
    {
        char ch1 = (char)i;
        if (i < 0x0d800 || i > 0xdfff)
        {
            string str1 = char.ConvertFromUtf32(i);
            if (str1.Length != 1)
            {
                Console.WriteLine("\\u+{0:x4}: char.ConvertFromUtf32(i).Length = {1}", i, str1.Length);
            }
            char ch2 = str1[0];
            if (ch1 != ch2)
            {
                Console.WriteLine("\\u+{0:x4}: (char)i = 0x{1:x4}, char.ConvertFromUtf32(i)[0] = 0x{2:x4}", i, (int)ch1, (int)ch2);
            }
        }
        byte[] bytes = BitConverter.GetBytes(i);
        string str2 = Encoding.UTF32.GetString(bytes);
        if (str2.Length != 1)
        {
            Console.WriteLine("\\u+{0:x4}: Encoding.UTF32.GetString(bytes).Length = {1}", i, str2.Length);
        }
        char ch3 = str2[0];
        if (ch1 != ch3)
        {
            Console.WriteLine("\\u+{0:x4}: (char)i = 0x{1:x4}, Encoding.UTF32.GetString(bytes)[0] = 0x{2:x4}", i, (int)ch1, (int)ch3);
        }
    }
