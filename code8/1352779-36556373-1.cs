    char temp = '\uFFF0';
    StringBuilder sb = new StringBuilder(Text);
    for (int i = 0; i < Indexes.Count; i++)
    {
        if (Indexes[i] < sb.Length)
        {
            sb[Indexes[i]] = temp;
        }
    }
    
    Text = sb.Replace(temp.ToString(), null).ToString();
