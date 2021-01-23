    using( StreamWriter w = new StreamWriter(@"C:\Temp\test\test.txt"))
    {
        for (int k = 0; k < ret.GetLength(0); k++)
        {
            w.Write("{");
            for (int l = 0; l < ret.GetLength(1); l++)
            {
                var val = ret[k, l];
                w.Write(val + ",");
            }
            w.Write("},");
            w.WriteLine(string.Empty);
        }
    }
