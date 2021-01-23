      private void RectangleButton_Click(object sender, EventArgs e)
    {
        actions.Add(new DrawAction('R', new Rectangle(11, 22, 66, 88), Color.DarkGoldenrod));
        mainPanel.Invalidate();  // this triggers the Paint event!
    }
    private void circleButton_Click(object sender, EventArgs e)
    {
        actions.Add(new DrawAction('E', new Rectangle(33, 44, 66, 88), Color.DarkGoldenrod));
        mainPanel.Invalidate();  // this triggers the Paint event!
    }
