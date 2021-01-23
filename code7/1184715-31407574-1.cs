    protected void cmdSave_Click2(object sender, EventArgs e)
    {
      string sFilePath = Server.MapPath("Database3.accdb");
      OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
      OleDbCommand cmd1 = new OleDbCommand("Select count(*) from Worker where username = '"+HttpContext.Current.User.Identity.Name+"'",con);
      int total = (Int32)cmd1.ExecuteScalar();
      con.Open();
      if(total==0)
      {
       OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
      string insertCmd = "INSERT INTO Worker(Business,Business2,Mobile,username) VALUES (@Business,@Business2,@Mobile,@useren)";
      using (Conn)
      {
        Conn.Open();
        OleDbCommand myCommand = new OleDbCommand(insertCmd, Conn);
        myCommand.Parameters.AddWithValue("@Business", business.Text);
        myCommand.Parameters.AddWithValue("@Business2", business2.Text);
        myCommand.Parameters.AddWithValue("@Mobile", mobile.Text);
        myCommand.Parameters.AddWithValue("@useren", HttpContext.Current.User.Identity.Name); 
        myCommand.ExecuteNonQuery(); 
        Label1.Text = "Saved Successfull!";
        Label1.ForeColor = System.Drawing.Color.Green;
        Conn.Close();
      }
      }
      else
      {
           Label1.Text = "Existing user";
      }
      con.Close();
    }
