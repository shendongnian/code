    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (dt1.Rows.Count == 1)
                {
                    if (dt1.Rows[0][0].ToString() == "Admin")
                    {
                        LoginInfo.UserID = txtUserName.Text;
                        Hide();
                        AdminForm admin = new AdminForm();
                        admin.Show();
                    }
                    if (dt1.Rows[0][0].ToString() == "Secretary")
                    {
                        LoginInfo.UserID = txtUserName.Text;
                        Hide();
                        frmMain main = new frmMain();
                        main.Show();
                    }
                    if (dt1.Rows[0][0].ToString() == "Employee")
                    {
                        LoginInfo.UserID = txtUserName.Text;
                        Hide();
                        EmployeeForm employee = new EmployeeForm();
                        employee.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                pnlSnackBar.Visible = true;
                lblMessage.Text = ex.Message;
                SnackBarTimer();
            }
        }
