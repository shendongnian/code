     if (!Page.IsPostBack)
     {
      string uname = Session["ApplicantUsername1"].ToString();
            txtUsername.Text = uname;
            cs.Open();
            SqlCommand cmd = new SqlCommand("SELECT  NoALastName, NoAFirstName, NoAMiddleName FROM CustomerCreditReport WHERE   ApplicantUsername = '" + uname + "'", cs);
    SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtLname.Text = reader["NoALastName"].ToString();
                txtFname.Text = reader["NoAFirstName"].ToString();
                txtMname.Text = reader["NoAMiddleName"].ToString();
            }
            cs.Close();
            reader.Close();
     }
