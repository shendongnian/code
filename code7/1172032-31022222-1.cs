    private void btnNotification_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            if (btn.Text == "ON")
            {
                btn.Text = "OFF";
                accept_notif = "0";
            }
            else if (btn.Text == "OFF")
            {
                btn.Text = "ON";
                accept_notif = "1";
            }
        }
    }
