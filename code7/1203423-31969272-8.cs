    Encoding enc = (Encoding)Encoding.GetEncoding("iso-2022-jp").Clone();
    enc.EncoderFallback = new EncoderReplacementFallback("");
    char[] chars = new char[1];
    byte[] bytes = new byte[16];
    var lst = new List<Tuple<byte[], char>>();
    for (int i = 0; i <= char.MaxValue; i++)
    {
        chars[0] = (char)i;
        int count = enc.GetBytes(chars, 0, 1, bytes, 0);
        if (count != 0)
        {
            var bytes2 = new byte[count];
            Array.Copy(bytes, bytes2, count);
            lst.Add(Tuple.Create(bytes2, chars[0]));
        }
    }
    lst.Sort((x, y) =>
    {
        int min = Math.Min(x.Item1.Length, y.Item1.Length);
        for (int i = 0; i < min; i++)
        {
            int cmp = x.Item1[i].CompareTo(y.Item1[i]);
            if (cmp != 0)
            {
                return cmp;
            }
        }
        return x.Item1.Length.CompareTo(y.Item1.Length);
    });
    using (StreamWriter sw = new StreamWriter(@"C:\temp\iso-2022-jp.txt"))
    {
        foreach (var tuple in lst)
        {
            sw.WriteLine(tuple.Item2);
            // This will print the full byte sequence necessary to 
            // generate the char. Note that iso-2022-jp uses escape
            // sequences to "activate" subtables and to deactivate them.
            //sw.WriteLine("{0}: {1}", tuple.Item2, string.Join(",", tuple.Item1.Select(x => x.ToString("x2"))));
        }
    }
