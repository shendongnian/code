    for (int i = 0; i < reader.FieldCount; i++)
    {
        sb.Append(reader.GetName(i));
        sb.Append(strDelimiter);
    }
