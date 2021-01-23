    public bool dbQuery(string sql, List<MySqlParameter> paramList= null)
    {
        bool flag = false;
        try
        {
            connect();
            cmd = new MySqlCommand(sql,con);
            cmd.Prepare();
            if(paramList != null)
             cmd.Parameters.AddRange(paramList.ToArray());
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
        }
        catch (Exception exc)
        {
            error(exc);
        }
    }
