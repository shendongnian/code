    private void password_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
        {
            if (password.Password == "drag0n")
            {
                e.Handled = true; // add this line
                btnActivate.IsEnabled = true;
            }
            else
            {
                btnActivate.IsEnabled = false;
            }
        }
    }
