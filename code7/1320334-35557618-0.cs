    StringBuilder sb = new StringBuilder();
    sb.Append("(");
    for (int i = 1; i <= trades.Count; i++)
    {
        sb.Append(trades[i]);
        sb.Append(")");
        if (i < trades.Count)
        {
            sb.Append(", (");
        }
    }
