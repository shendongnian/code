    private void button1_Click(object sender, EventArgs e)
    {
        if (this.ValidateChildren())
        {
            //Do registration here
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
