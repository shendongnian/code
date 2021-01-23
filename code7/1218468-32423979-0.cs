        string loginsql = "SELECT Username, UserType FROM tblAccount WHERE Username = '" + txtUser.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = '" + txtPass.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS AND EmpStatus = 'Active'";
        SqlDataAdapter loginda = new SqlDataAdapter(loginsql, con);
        DataTable logindt = new System.Data.DataTable();
        loginda.Fill(logindt);
        
        if (logindt.Rows.Count == 1)
            {
                Session["UserType"] = logindt.Rows[0][1].ToString();
                MessageBox.Show("Login Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HomeForm home = new HomeForm(logindt.Rows[0][0].ToString());
                home.Show();
                this.Hide();
            }
