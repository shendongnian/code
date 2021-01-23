    try
    {
         string myConnection = "datasource=s59.hekko.pl;port=3306;username=truex2_kuba;password=xxx";
         string Query = "insert into truex2_kuba.users (uid,password) values(@user,@pass);";
         using (MySqlConnection myConn = new MySqlConnection(myConnection))
          {
            MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn); 
            cmdDataBase.Parameters.AddWithValue("@user",uid.Text);
            cmdDataBase.Parameters.AddWithValue("@pass",pwd.Text);
            myConn.Open();
            cmdDataBase.ExecuteNonQuery();                
            MessageBox.Show("Użytkownik Stworzony");             
          }
    }
    catch (SQlException ex)
     {
       MessageBox.Show(ex.Message);
     }
