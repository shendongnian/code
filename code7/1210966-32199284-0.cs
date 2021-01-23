     protected void btnConfirmPassword_Click(object sender, EventArgs e)
            {
                if (txtPassword.Password == "XX")
                {
                    uploadDownloadPanel.Visible = true;
                    passwordPanel.Visible = false;
                }
            }
