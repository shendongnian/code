    bool handled = true;
    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            /*Prevent handling the Enter key twice*/
            handled = !handled;
            if(handled)
                return;
            //Rest of logic
            //OkButton.PerformClick();
        }
    }
