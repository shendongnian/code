    protected void Button2_Click(object sender, EventArgs e)
    {
        string st = "SELECT F_L FROM split_master where First_name=@val ";
        using (sqlcon){
        sqlcon.Open();
        cmd = new SqlCommand(st, sqlcon);
        cmd.Parameters.AddWithValue("@val", TextBox1.Text);
        SqlDataReader sqlread = cmd.ExecuteReader();
    
        while (sqlread.Read())
        {
    
            string[] word = sqlread["F_L"].ToString().Split(' ');
               try{
              foreach(string words in word)
               {
               Console.WriteLine(words);
               }
                   }
              catch{}
          
          }
                       }
    }
