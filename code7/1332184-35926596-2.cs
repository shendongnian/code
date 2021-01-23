    for (int i = 0; i < reader.FieldCount; i++)
    {
        sb.Append(reader.GetName(i));
        if (i == reader.FieldCount - 1)
            continue;
        sb.Append(strDelimiter);
    }
