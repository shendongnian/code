    public List<Test> GetData()
    {
        List<Test> myList = new List<Test>();
        string sqlQuery = "Select Title, Result From Test";
        string connectionString = ConfigurationManager.ConnectionStrings["Test1.ConnectionString"].ConnectionString; //Read connection string from config file
        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand(sqlQuery, con))
            {
                //Add param here if required.
                con.Open(); //Open connection
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Test t = new Test();
                        t.Title = reader["Title"].ToString();
                        t.Result = Convert.ToInt32(reader["Result"]);
                        myList.Add(t);
                    }
                }
            }
        }
        return myList;
    }
