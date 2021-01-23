    private bool IsValid = false;
    private void textBox1_Validated(object sender, EventArgs e)
    {
        this.ValidateUser(textBox1.Text);
    }
    private async void ValidateUser(string username)
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        IsValid = await client.CheckUser(textBox1.Text);
        if (IsValid) {
            MessageBox.Show("Welcome!");
        } else {
            MessageBox.Show("Invalid Username, try again!");
            textBox1.Focus();
        }
    }
