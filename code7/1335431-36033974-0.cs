    private async void button1_Click(object sender, EventArgs e)
    {
        if ((await LoginUser(tUser.Text, Password.Text)).IsSuccessStatusCode)
        {
            Notifier.Notify("Successfully logged in.. Please wait!");
        }
        else
        {
            Notifier.Notify("Please check your Credential..");
        }            
    }
