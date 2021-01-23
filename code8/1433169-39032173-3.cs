    public void ReadDataFromDB(string Year, string Place)
    {
        string sql = @"select a.FALL, m.CODE, m.ANZ, m.TDAT From lst_test m with (nolock)
    inner join test2 a with (nolock) on a.aid = m.aid 
    where 1=1 ";
    
        if (Year != null && Year.Length > 0)
        {
            sql += "AND year(m.TDAT) = @jahr ";
        }
        if (Place != null && Place.Length > 0)
        {
            sql += "AND m.Einrichtung=  @einricht  ";
        }
        sql += "order by a.FALL";
        adapter = new SqlDataAdapter(sql, "Server = sds; Database = dds;Trusted_Connection = True");
    }
