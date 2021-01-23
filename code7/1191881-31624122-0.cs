    StringBuilder SB= new     StringBuilder();
    foreach (char ch in theDate1)
    {
        SB.Append(ch);
        SB.Append(" ");
    }
    var result =SB.ToString().TrimEnd();
