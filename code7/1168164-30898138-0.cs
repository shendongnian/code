    private void btnAdd_Click(object sender, EventArgs e)
    {
      try
      {
        iD++;
        this.GetEmployee = new Employee(iD, txtFirstName.Text, txtLastName.Text, txtEmail.Text);
        this.DialogResult = DialogResult.OK;   
      }
      catch (ArgumentNullException msg)
      {
        MessageBox.Show(msg.Message);
      }
    }
