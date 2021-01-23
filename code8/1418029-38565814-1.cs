    using(var mDB = new SqlConnection(connectionString))
    {
        mDB.Open();
        using(var cmd = new SqlCommand("SELECT * FROM Employee", mDB))
        using(var rdr = cmd.ExecuteReader())
        {
            
            while (rdr.Read() == true)
            {
                if (txtUsername.Text == (string)rdr["eUserName"] &&
                    txtPassword.Text == (string)rdr["ePassword"])
                 {
                    Session["sFlag"] = "T"; // sFlag = "T" means user has logged in
                    Session["sFirstName"] = rdr["eFirstName"];
                    Session["sLastName"] = rdr["eLastName"];
                    Session["sUsername"] = rdr["eUserName"];
                    btnLogout.Visible = true;
                    btnLogin.Visible = false;        
                } //end of if
            } //end of while loop
        }
    }
