    try
    {
        if (Decrypt(GetPassword(tb_Username)) != tb_Password)
        {
            MessageBox.Show("Incorrect credentials");
            return;
        }
        Find_Resource show_now = new Find_Resource();
        show_now.Show();
        this.Hide();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
        
