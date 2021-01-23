    if (result.Rows.Count == 1)
        {
            this.Hide();
            string role = result.Rows[0]["Role"].ToString();
            switch (role)
            {
                case "User":
                    FrmUser fuser = new FrmUser();
                    fuser.ShowDialog();
                    // note that this.Close() removed
                    break;
                case "Admin":
                    FrmMain fmain = new FrmMain();
                    fmain.ShowDialog();
                    // note that this.Close() removed
                    break;
            }
        }
        else
        {
            MessageBox.Show ("Invalid User Name or Password", "Incorrect Login Details",MessageBoxButtons.OK,MessageBoxIcon.Error);
            Application.Exit(); // optional, use if you want to exit all app window when wrong credentials supplied
        }
