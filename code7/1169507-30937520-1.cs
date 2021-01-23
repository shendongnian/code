       private void txtName_TextChanged(object sender, EventArgs e)
       {
        
        //here is the problem add ! in font 
        
        if(!String.IsNullOrWhiteSpace(txtName)) // This will prevent exception when textbox is empty   
        {
        if (!System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Enter Valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text.Remove(txtName.Text.Length - 1);
                txtName.Clear();
                txtName.Focus();
             }
        }
       }
