     private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var connect = sqlcon.getConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rights FROM employee WHERE username = @username AND password = @password"))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    cmd.Parameters.Add("@username", SqlDbType.Char).Value = tbUsername.Text;
                    cmd.Parameters.Add("@password", SqlDbType.Char).Value = tbPassword.Text;
                    //SqlDataReader re = cmd.ExecuteReader();
                    string aeRights = (string)cmd.ExecuteScalar();
                    if (aeRights == "1")
                    {
                        frmAdmin frmA = new frmAdmin();
                        frmA.Show();
                        this.Hide();
                    }
                    else if (aeRights == "2")
                    {
                        frmEmp frmE = new frmEmp();
                        frmE.Show();
                        this.Hide();
                    }
                    else if (string.IsNullOrEmpty(aeRights))
                    {
                        MessageBox.Show("Invalid username or password! Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }              
            }
        }
