    public bool dbQuery(string sql,string[] paramList= null)
    {
        bool flag = false;
        try
        {
            connect();
            cmd = new MySqlCommand(sql,con);
            cmd.Prepare();
            if(paramList != null){ 
                foreach(string i in paramList){
                    string[] valus = i.Split(',');
                    string p = valus[0];
                    string v = valus[1];
                    cmd.Parameters.AddWithValue(p, v);
                }
            }
            if (cmd.ExecuteNonQuery() > 0)
               flag = true;
        }
        catch (Exception exc)
        {
            error(exc);
        }
    }
