    {
        SqlConnection Conn = new SqlConnection();
        Conn.ConnectionString = yourConnectionString;
        Conn.Open();
        SqlCommand check_idexistcomm = new SqlCommand();
        check_idexistcomm.Connection = Conn;
        check_idexistcomm.CommandText = "SELECT id FROM yourtable";
        var check_idexistda = new SqlDataAdapter(check_idexistcomm);
                                    
        SqlDataReader check_idexistreader = check_idexistcomm.ExecuteReader();
        while (check_idexistreader.Read())
        {
            if (check_idexistreader["id"].ToString()== text value inputed by user here)
            {   
              idfound = true;
              break;
            }
        }
        check_idexistreader.Close();
        Conn.Close();
        if (idfound=true)
        {
            your code here to accept the user as authorized
        }
        else
        {
            MessageBox.Show("Sorry, you're not authorized");
        }
    }
