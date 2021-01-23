     protected void btnRegister_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Email FROM Users WHERE Email=@Email";
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                    error.Visible = true;
                    emailavail.Visible = false;
                    success.Visible = false;
                    con.Close(); 
            }
            else
            {
               
                success.Visible = false;
                con.Close();
                RegisterUser();
            }
             
            
            
        }
        void RegisterUser()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Users VALUES (@TypeID, @Email, @Password, " +
                "@FirstName, @LastName, @CompanyName, @Street, @Municipality, @City, @CompanyPhone, @Mobile, " +
                "@Status, @DateAdded, @DateModified)";
            cmd.Parameters.AddWithValue("@TypeID", "2");
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", Helper.CreateSHAHash(txtPassword.Text));
            cmd.Parameters.AddWithValue("@FirstName", txtFN.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLN.Text);
            cmd.Parameters.AddWithValue("@CompanyName", txtCName.Text);
            cmd.Parameters.AddWithValue("@Street", txtStreet.Text);
            cmd.Parameters.AddWithValue("@Municipality", txtMunicipality.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@CompanyPhone", txtCPhone.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
            cmd.Parameters.AddWithValue("@Status", "Pending");
            cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateModified", DBNull.Value);
            cmd.ExecuteNonQuery();
            con.Close();
        }
