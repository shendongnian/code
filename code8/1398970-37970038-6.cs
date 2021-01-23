    private void btnSeparate_Click(object sender, EventArgs e)
    {
        TextBox txtFullName = new TextBox();
        txtFullName.Text = String.Empty;
    
        if(txtFullName.Text.Split(' ').Length == 3 && !txtFullName.Text.ToLower().Contains("stop"))
        {
            // Save array of splitted parts
            string[] nameParts = txtFullName.Text.Split(' ');
                    
            // This is never used??
            string strfirstname = nameParts[1];
    
            // Set name-parts to labels
            lblGivenEntered.Text = nameParts[0];
            lblFamilyEntered.Text = nameParts[2];
        }
        else if(txtFullName.Text.Split(' ').Length != 3)
        {
            // If there are no 3 words, handle it here - MessageBox?
        }
    }
