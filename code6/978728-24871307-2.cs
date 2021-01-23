    StringBuilder builder = new StringBuilder();
    foreach (var item in formattedLines)
    {
        builder.AppendLine(item.Number.ToString());
        builder.AppendLine(item.Data);
    }
    string output = builder.ToString();
