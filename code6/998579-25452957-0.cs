    public int getAge_Test(string Name)
    {
    string sql = "Select Age from profile where Name = @Name ;";
      using (var con = new MySqlConnection("server=127.0.0.1;user id=root;persistsecurityinfo=True;database=social_media"))
            using (var cmd = new MySqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 50).Value = Name; //MySQL has no defintion for SqldbType and also Nvarchar
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DateTime origin = reader.GetDateTime(0);
                        //calculate the age
                        int Age = DateTime.Today.Year - origin.Year;
                        if (origin > DateTime.Today.AddYears(-Age)) Age--; //Visual Studio also does not know "today", just "DateTime.Today"
                        return Age;
                    }
                }
            }
            return 0; //or throw an exception here
        }
 
