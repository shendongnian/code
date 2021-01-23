    private void btnCreate_Click(object sender, EventArgs e) {
      String fileName = Path.Combine(txtUsername.Text, ".txt");
    
      if (File.Exists(fileName)) 
        MessageBox.Show("Already used ", "Use diferent name");
      else { 
        // OK
        File.WriteAllText(fileName, txtPassword.Text); 
        Close(); // if you want to close form here
      }
    }
