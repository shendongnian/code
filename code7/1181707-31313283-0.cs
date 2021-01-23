    var param = new List<MySqlParameter> { new MySqlParameter("compid", CompanyID) };
    StringBuilder SQL = new StringBuilder(SearchSQL);
    if (SearchFieldKey != null && SearchFieldKey.Length > 0)
    {
        SQL.Append(" AND (");
        for (int i = 0; i < SearchFieldKey.Length; i++)
        {
            if (SearchFields.ContainsKey(SearchFieldKey[i]))
            {
                SQL.Append("(");
                SQL.Append(SearchFields[SearchFieldKey[i]]);
                SQL.Append(") LIKE ?parameter");
                SQL.Append(i);
                param.Add(new MySqlParameter("parameter" + i.ToString(), "%" + SearchTerms[i] + "%"));
    
                if (i != SearchFieldKey.Length - 1)
                    SQL.Append(" OR ");
            }
            else
                throw new Exception("Error: Attempted to search on invalid field. Check SearchFields Argument.");
        }
        SQL.Append(") ");
    }
