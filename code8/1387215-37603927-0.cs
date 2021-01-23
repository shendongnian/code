            SqlCommand getlev = new SqlCommand("SELECT level FROM [User] WHERE Username like @user", c);
            getlev.Parameters.AddWithValue("@user", txtuser.Text);
             c.Open();
             int a = (int)getlev.ExecuteScalar();
             c.Close();
    
             if (a>5){
                 CVSemi.IsValid = false;
    
                 if (a >= 10) {
                     CVmax.IsValid = false;
                  }
                  else {
                       CVmax.IsValid = true;
                  }
              else
              {
                    CVSemi.IsValid = true;
               }
        else
        {
            CVName.IsValid = false;
            txtuser.CssClass = "err";
        }
