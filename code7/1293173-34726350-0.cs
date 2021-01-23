         public void Some_procedure()
         {
            SqlConnection con = new SqlConnection(Conection_string.conection);
            try
                {
                    con.Open();
                    //Here the code to execute soomething from data base....
                    con.Close();
                }
                catch (Exception ex)
                {
                    string ms;
                    ms = ex.Message;
                }
                //This will ensure that al resources in server are available
                finally
                {
                    con.Close();
                }
        }
