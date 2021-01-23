    if (string.IsNullOrWhiteSpace(txtName.Text) || 
     string.IsNullOrWhiteSpace(txtID.Text) ||
     string.IsNullOrWhiteSpace(txtSalary.Text) ||
     string.IsNullOrWhiteSpace(txtERR.Text)) 
     {
      MessageBox.Show("One or more text fields are empty or hold invalid data, please correct this to continue","Data Error",MessageBoxButtons.OK);
      return;
     }
