    private void pnlButtons_Click(object sender, EventArgs e)
    {
        Point ptClick = Control.MousePosition;
        foreach (Control cntrl in pnlButtons.Controls)
        {
            // Make sure the control is visible!
            if (cntrl.Visible)
            {
                // Click close to control?
                if ((ptClick.X > (cntrl.Left - 5)) &&
                    (ptClick.X < (cntrl.Right + 5)) &&
                    (ptClick.Y > (cntrl.Top - 5)) &&
                    (ptClick.Y < (cntrl.Bottom + 5)))
                {
                    PerformActionsOnClick();
                }
            }
        }
    }
    private void MyButton_Click(object sender, EventArgs e)
    {
        PerformActionsOnClick();
    }
    void PerformActionsOnClick()
    {
        //do your stuff here
    }
