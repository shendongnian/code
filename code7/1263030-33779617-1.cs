    private void btnHide_Click(object sender, EventArgs e)
    {
        string[] buttonList = { "button1", "button2", "button3" };
        for (int i = 0; i < buttonList.Length; i++)
        {
            Control[] ctrl = this.Controls.Find(buttonList[i], true);
            ((Button)ctrl[0]).Visible = false;
        }
    }
