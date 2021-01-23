    private void button1_Click(object sender, EventArgs e)
    {
        string accountsSettingsFile = Path.GetDirectoryName(Application.LocalUserAppDataPath)
                + "\\accounts" + "\\accounts.txt";
        if (!File.Exists(accountsSettingsFile))
            File.Create(accountsSettingsFile);     
        
        //New Code
        StringBuilder accountText = new StringBuilder();
        accountText.AppendLine(textbox1.Text);
        accountText.AppendLine(textbox2.Text);       
        accountText.AppendLine(textbox3.Text);
        accountText.AppendLine(checkbox.Checked.ToString().ToLowerInvariant());
        //Above line assumes you want a trailing newline
        System.IO.File.WriteAllText(accountsSettingsFile, accountText.toString());
    }
