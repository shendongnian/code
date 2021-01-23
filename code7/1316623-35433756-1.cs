    StringBuilder sb = new StringBuilder();
    // fill StringBuilder 
    using (StreamWriter sw = new StreamWriter(@"c:\file.txt"))
    {
        for (int i = 0; i < sb.Length; i++)
        {
            sw.Write(sb[i]);
        }
    }
