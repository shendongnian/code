    StringBuilder sb = new StringBuilder();
    sb.Append("insert into ");
    sb.Append(tableName);
    sb.Append(" (");
    StringBuilder sbValues = new StringBuilder();
    sbValues.Append("values (");
    bool first = true;
    foreach (KeyValuePair<string, object> kvp in d)
    {
        if (first)
        {
            first = false;
        }
        else
        {
            sb.Append(", ");
            sbValues.Append(", ");
        }
        sb.Append(kvp.Key);
        sbValues.Append("?");
        // put the value in a SQL parameter;
        dbfCmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
    }
    sb.Append(") ");
    sbValues.Append(")");
    sb.Append(sbValues.ToString());
    string fullSql = sb.ToString();
