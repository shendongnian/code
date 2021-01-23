    private void button1_Click(object sender, EventArgs e)
    {
        if (this.ValidateChildren())
        {
            //Here the form is in valid state
            //Do what you need when the form id valid
        }
        else
        {
            var listOfErrors = this.errorProvider1.ContainerControl.Controls.Cast<Control>()
                                   .Select(c => this.errorProvider1.GetError(c))
                                   .Where(s => !string.IsNullOrEmpty(s))
                                   .ToList();
            MessageBox.Show("Please correct validation errors:\n - " +
                string.Join("\n - ", listOfErrors.ToArray()),
                "Error",  
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
