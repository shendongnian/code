    string constring = "datasource=localhost;port=3306;username=root;password=root";
    string Query = "update  database.check set  namethestore = 
    @namethestore,checkername=@checkername where namethestore = @namethestore";
    using(MySqlConnection conDataBase = new MySqlConnection(constring))
    {
      using(MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
       {
         conDataBase.Open();
         cmdDataBase.CommandText = Query;
         cmdDataBase.Parameters.Add("@namethestore", this.textBox65.Text);
         cmdDataBase.Parameters.Add("@checkername", this.textBox66.Text);
    
         cmdDataBase.ExecuteNonQuery();
       }
    }
