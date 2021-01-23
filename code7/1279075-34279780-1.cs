    bool visible = false;
    private void KeyPress(object sender, KeyEventArgs e)
    {
        PlayerInfo playerInfo = new PlayerInfo(this);
        if (e.KeyCode == Keys.C)
        {
            if (visible == false)
            {
                playerInfo.Show();
                visible = true;
            } 
            else if (visible)
            {
                playerInfo.Hide();
                visible = false;
            }
        }
    }
