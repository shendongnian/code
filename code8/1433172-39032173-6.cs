    public void ReadDataFromDB(string Year, string Place)
    {
        string sql = @"select a.FALL, m.CODE, m.ANZ, m.TDAT From lst_test m with (nolock)
    inner join test2 a with (nolock) on a.aid = m.aid ";
    
        if (Year != null && Place != null)
        {
          sql += "Where year(m.TDAT) = @jahr AND m.Einrichtung=  @einricht ";
        }
        else if (Year != null && Place == null)
        {
          sql += "Where year(m.TDAT) = @jahr ";
        }
        else if (Place != null && Year == null)
        {
          sql += "Where m.Einrichtung=  @einricht ";
        }
        sql += "order by a.FALL";
        adapter = new SqlDataAdapter(sql, "Server = sds; Database = dds;Trusted_Connection = True");
    }
