    private bool isExiting = false;
    
    private void Approve_User_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (isExiting)
                       return;
    
                if (MessageBox.Show("Do you really want to QUIT application...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isExiting = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
    
            }
