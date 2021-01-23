    Encoding encoding = Encoding.GetEncoding("iso-2022-jp");
    using (var stream = new FileStream(@"C:\iso-2022-jp.txt", FileMode.Create))
    {
        using (StreamWriter writer = new StreamWriter(stream, encoding))
        {
            for (int i = 0; i <= char.MaxValue; i++)
            {
                // Each char goes separate line. One will be only 1 byte, others more with
                // the leading escape seq:
                writer.WriteLine(((char) i).ToString());
            }
        }
    }
