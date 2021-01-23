        string strMessage = "coolsssss";
        string hexedString = string.Join("", strMessage.Select(c => String.Format("{0:X2}", (int)c)))
                                .PadRight((strMessage.Length + 3) / 4 * 8, '0');
        StringBuilder sb = new StringBuilder(strMessage.Length * 9 / 4 + 10);
        int count = 0;
        foreach (char c in strMessage)
        {
            if (count == 4)
            {
                sb.Append(" ");
                count = 0;
            }
            sb.Append(String.Format("{0:X2}", (int)c));
            count++;
        }
        for (int i = 0; i < (4 - count) % 4; ++i)
        {
            sb.Append("00");
        }
        // DEBUG: echo results for testing.
        Console.WriteLine("");
        Console.WriteLine("String provided: {0}", strMessage);
        Console.WriteLine("Hex equivalent of string provided: {0}", hexedString);
        Console.WriteLine("Hex in 8-digit chunks: {0}", sb.ToString());
        Console.WriteLine("======================================================");
