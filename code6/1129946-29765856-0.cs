    ToolTip Message = new ToolTip();
    MyIcon.MouseHover += ShowToolTip;
    private void ShowToolTip(object sender, EventArgs e)
        {
            Message.Show("Bladiebla",MyIcon);
        }
