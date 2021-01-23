    private void showPanel(Object sender, EventArgs e)
        {
            if (sender == dashPanelButton)
            {
                dashPanel.Visible = true;
            }
            else if (sender == studInfoBtn)
            {
                studInfoBtn.Visible = true;
            }
            else
            {
                homePanel.Visible = true;
            }
        }
