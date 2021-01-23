    for (int i = 0; i < items.Count; i++)
    {
        var item = items[i];
        sb.Append(item);
        if (i == items.Count - 1)
        {   
            // skip delimiter for final item
            continue;
        }
        sb.Append(strDelimiter);
    }
