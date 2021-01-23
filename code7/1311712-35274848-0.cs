    using (reader = new SqlCommand(query, conn).ExecuteReader())
    {
        for (int i=0; i<reader.FieldCount; i++)
        {
            sb.Append(reader.GetName(i));
            sb.Append(strDelimiter);
        }
        sb.Append(Environment.NewLine);
        // your code here...
        if (reader.HasRows)
        {
            // etc...
        }
    }
