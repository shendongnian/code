    using (BinaryReader br = new BinaryReader(File.Open(yourFile, FileMode.Open)))
    {
        var data =  br.ReadChars  ((int)br.BaseStream.Length);
        StringBuilder sb = new StringBuilder();
        foreach (char c in data) 
                 if ((int)c > 0) sb.Append(c.ToString()); else sb.Append(".");
        text2.Text = sb.ToString();
    }
