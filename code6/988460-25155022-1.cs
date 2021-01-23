    var sb = new StringBuilder();
    
    foreach (char t in sample)
    {
        if (!pattern2.Contains(t))
        {
            sb.Append(t);
        }
    }
    
    result = sb.ToString();
