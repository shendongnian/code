    private void firstContacts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (firstContacts.Focused)
        {
            string[] words = firstContacts.SelectedItem.ToString().Split(" ".ToCharArray());
            if (words.Length != 3)
            {
                throw new Exception("Wrong format");
            }
            txtFirstName.Text = words[0];
            txtLastName.Text = words[1];
            txtPhoneNumber.Text = words[2];
        }
