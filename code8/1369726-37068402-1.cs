            if (count == 1)
            {
                MessageBox.Show("Login Successful!");
                LoggedUser.Name = ds.Tables[0].Rows[1].ToString();
                LoggedUser.Username = ds.Tables[0].Rows[2].ToString();
                this.Hide();
                frmOverview fo = new frmOverview();
                fo.Show();
            }
