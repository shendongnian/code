    private void btnNotification_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
            if (btn.Text == "ON")
                btn.Text = "OFF";
            else if (btn.Text == "OFF")
                btn.Text = "ON";
        }
    }
