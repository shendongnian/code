    this is my login form codes :
                            if (count == 1)
                            {
                                
                                UserInformation.CurrentLoggedInUser = (string)rdr["UserName"];
                                MessageBox.Show("Welcome " + comboBox1.Text + UserInformation.CurrentLoggedInUser);
                                UserInformation.CurrentLoggedInUser = (string)rdr["UserRole"];
                                if (UserInformation.CurrentLoggedInUser == "Administrator")
                                {
                                    this.Close();
                                    this.MdiParent = new Form1();
                                   // ((Form1)this.MdiParent).hide();
                                    //((Register_Training_Participant)this.MdiParent).Hide();
                                    var parent = (Form1)MdiParent;
                                    parent.AdminDisableControl();
                                    
                                    
                                }
    //this is the code for my mainform :
    public void AdminDisableControl()
            {
                regToolStripMenuItem.Visible = false;
    
            }
