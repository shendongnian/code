    var stringBuilder = new StringBuilder();
    foreach(var line in GetLines())
    {
        stringBuilder.AppendLine(log);
    }
    return Encoding.ASCII.GetBytes(stringBuilder.ToString());
