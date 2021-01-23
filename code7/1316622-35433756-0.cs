    StringBuilder sb = new StringBuilder();
    // fill StringBuilder 
    for (int i = 0; i < sb.Length; i++)
    {
        using (StreamWriter sw = new StreamWriter(@"c:\file.txt"))
        {
            sw.Write(sb[i]);
        }
    }
