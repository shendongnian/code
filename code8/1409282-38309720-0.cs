    private List<string> GetNames() {
        var myList = new List<string>();
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
        while (sqlReader.Read())
            {
                string name = sqlReader.GetString(0);
                myList.Add(name);
            }
        sqlReader.Close();
        conn.Close();
        return myList;
    }
