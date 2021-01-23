    private void Login_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (Login.role != "Admin")
        {
            MessageBox.Show("You are not authorized to Exit Application.");
            e.Cancel = true;
        }
        else 
        {
            Application.Exit();
        }
    }
