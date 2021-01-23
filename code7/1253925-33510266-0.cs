    string a = "1AD9B1E7D11FEA4F4C89493E1";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < a.Length; i++)
    {
        if (i % 4 == 0 && i != 0)
            sb.Append(' ');
        sb.Append(a[i]);
    }
    string formatted = sb.ToString();
    string[] splitted = formatted.Split(' ');
    
