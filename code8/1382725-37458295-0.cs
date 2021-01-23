    var output = new string[temp.GetUpperBound(0)+1];
    for (int i = 0; i<=temp.GetUpperBound(0); i++)
    {
        var sb = new StringBuilder(temp.GetUpperBound(1)+1);
        for (int j = 0; j<=temp.GetUpperBound(1); j++)
            sb.Append(temp[i,j]);
        output[i] = sb.ToString();
    }
