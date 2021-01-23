    public static string CreateEditSql(string table, IDictionary<string, string> parameterMap, string werename, string weretext)
        {
            var keys = parameterMap.Keys.ToList();
            // ToList() LINQ extension method used because order is NOT
            // guaranteed with every implementation of IDictionary<TKey, TValue>
            var sql = new StringBuilder("UPDATE ").Append(table).Append(" SET ");
            for (var i = 0; i < keys.Count; i++)
            {
                sql.Append(keys[i]).Append(" = @").Append(keys[i]);
                if (i < keys.Count - 1)
                    sql.Append(", ");
            }
            return sql.Append(" WHERE ").Append("`").Append(werename).Append("`").Append(" = ").Append(weretext).ToString();
        }
        public void SqlEdit(string table, IDictionary<string, string> parameterMap,string werename , string weretext)
        {
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            {
                using (var command = conn.CreateCommand())
                {
                    command.Connection = conn;
                    command.CommandText = CreateEditSql(table, parameterMap,werename,weretext);
                    foreach (var pair in parameterMap)
                        command.Parameters.Add(pair.Key, pair.Value);
                    command.ExecuteNonQuery();
                }
            }
        }
    access.SqlEdit("`employee`", new Dictionary<string, string>() 
                    {
                      //  { "e_name",txt_nameedit.Text },
                        { "e_name",txt_name.Text },
                      //  { "e_pic",ImageData.ToString() },
                       // { "e_datebegin",txt_bigdate.Value.ToString("yyyyMMdd") },
                        //{ "e_datebirth",txt_date.Value.ToString("yyyyMMdd") },
                        //{ "e_loc",txt_loc.Text },
                       // { "e_mony",txt_mony.Text },
                       // { "e_mob",txt_mob.Text },
                       // { "e_use",txt_user.Text },
                       // { "e_pass",txt_pass.Text },
                       // { "e_prv",txt_prv.Text },
                    }, "e_name", txt_nameedit.Text);
