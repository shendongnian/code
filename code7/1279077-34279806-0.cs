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
