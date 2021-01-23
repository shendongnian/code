    private void KeyPress(object sender, KeyEventArgs e)
    {
     if (e.KeyCode == Keys.C)
        {
            if (!visible)
            {
                playerInfo.Show();
                visible = true;
            } 
            else
            {
                playerInfo.Hide();
                visible = false;
            }
        }
    }
