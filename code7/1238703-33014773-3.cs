    private void ValidationTest_Load(object sender, EventArgs e)
    {
        this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
    }
    private void passwordTextBox_Validating(object sender, CancelEventArgs e)
    {
        if (this.passwordTextBox.TextLength < 8)
        {
            this.errorProvider1.SetError(this.passwordTextBox, "Password must be at least 8 character");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider1.SetError(this.passwordTextBox, "");
        }
    }
    private void confirmTextBox_Validating(object sender, CancelEventArgs e)
    {
        if (this.confirmTextBox.Text != this.passwordTextBox.Text)
        {
            this.errorProvider1.SetError(this.confirmTextBox, "Password and Confirm must be the same");
            e.Cancel = true;
        }
        else
        {
            this.errorProvider1.SetError(this.confirmTextBox, "");
        }
    }
    private void registerButton_Click(object sender, EventArgs e)
    {
        if (this.ValidateChildren())
        {
            //Do registration here
        }
        else
        {
            var listOfErrors = this.errorProvider1.ContainerControl.Controls
                                .Cast<Control>()
                                .Select(c => this.errorProvider1.GetError(c))
                                .Where(s => !string.IsNullOrEmpty(s))
                                .ToList();
            MessageBox.Show("please correct validation errors:\n - " +
                string.Join("\n - ", listOfErrors.ToArray()),
                "Error",  
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
