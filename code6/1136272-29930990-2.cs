    private boolean splashShown = Properties.Settings.Default.splashShown;
    
    private void Form_Load(object sender, EventArgs e)
    {
        if (!splashShown)
        {
            MessageBox.Show("message");
            myForm.Properties.Settings.Default.splashShown = true;
            myForm.Properties.Settings.Default.Save();
        }
    }
