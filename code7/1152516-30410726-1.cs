    ....
    public bool getEmail()
    {
        string email = txtEmail.Text;
        bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        if (isEmail)
        {
            validEmail = email;
            return true;
        }
        else
        {
            MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if(!getEmail())
           this.DialogResult = DialogResult.None;
    }
