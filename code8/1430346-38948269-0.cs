      private void btnLogin2_Click(object sender, EventArgs e)
            {
                int value;
                if (int.TryParse(txtLogin2.Text, out value)) {
                            MessageBox.Show("User ID not in valid format");
                }
                if (txtLogin2.Text == "" )
                {
                            MessageBox.Show("Please enter a User ID");
                }
                if (txtPassword2.Text == "") {
                            MessageBox.Show("Please enter a valid Password");
                }
                //You have bypass the error checking here.              
                if (txtLogin2.Text != "" && txtPassword2.Text != "")
                {
                    int AID = Convert.ToInt32(txtLogin2.Text);
                    Entities2 db = new Entities2();
                    Administrator admin = db.Administrators.Where(x => x.AID == AID && x.Password == txtPassword2.Text).SingleOrDefault();
                    if (admin != null)
                    {
                        Admin admini = new Admin();
                        admini.ShowDialog();
                    }
                }
                else
                {
                      MessageBox.Show("Please enter username and password";
                }
            }
