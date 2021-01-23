    public int getAge(string Name) 
    {
        string sql = "Select Age from profile where Name = @Name ;";
        using (var cn = new MySqlConnection("connection string here"))
        using (var cmd = new MySqlCommand(sql, cn))
        { 
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name;  
            cn.Open();          
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    DateTime origin = Reader.GetDateTime(0);
                    //calculate the age
                    int Age = DateTime.Today.Year - origin.Year;
                    if (origin > today.AddYears(-Age)) Age--;
                    return Age;
                }
            }
        }
        return 0; //or throw an exception here
    }
