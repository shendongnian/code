     OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [users] Where [UserName]='" + txtUserName.Text + "' And [pwd]='" + txtPassword.Text + "' And [Roll]='" + cmbroll.Text + "'", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (cmbroll.Text == "Admin")
                    {
                        MainFrm f = new MainFrm();
                        f.Show();
                        f.lblLogedUser.Text = txtUserName.Text;
                        this.Hide();
                    }
                    else {
                        MainFrmUser userform = new MainFrmUser();
                        userform.Show();
                        userform.lblLogedUser.Text = txtUserName.Text;
                        this.Hide();
                    }
 
