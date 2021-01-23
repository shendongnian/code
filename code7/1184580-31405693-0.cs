     StringBuilder SQL = new StringBuilder(SearchSQL);
                if (SearchFieldKey != null && SearchFieldKey.Length > 0)
                {
                    if (SearchTerms != null)
                    {
                        SQL.Append(" HAVING ");
                        for (int i = 0; i < SearchFieldKey.Length; i++)
                        {
                            if (SearchFields.ContainsKey(SearchFieldKey[i]))
                            {
    
                                SQL.Append(SearchFields[SearchFieldKey[i]] + " LIKE ', ?parameter" + i.ToString());
                                param.Add(new MySqlParameter("parameter" + i.ToString(), "\'%" + SearchTerms[i] + "%\'"));
    
                                if (i != SearchFieldKey.Length - 1)
                                    SQL.Append("', OR ");
    
                            }
                            else
                                throw new Exception("Error: Attempted to search on invalid field. Check SearchFields Argument.");
                        }
                    }
    
                }
                else
                {
                    SQL.Append("'");
                }
    
                SQL.Append("); ");
                SQL.Append ("prepare stmt from @sql; execute stmt; deallocate prepare stmt;");
