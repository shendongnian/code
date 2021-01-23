    private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Select Type from Logins where Username='@user' and Password='@pass'", scon);
                cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                sda1 = new SqlDataAdapter(cmd);
                dt1 = new DataTable();
                sda1.Fill(dt1);
            }
            catch (Exception ex)
            {
                //pnlSnackBar.Visible = true;
                lblMessage.Text = ex.Message;
                SnackBarTimer();
            }
        }
