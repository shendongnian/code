    private void pnlMouseLeave(object sender, EventArgs e)
    {
        Panel panel1 = sender as Panel; // ← Your code
        Point mousePosition = PointToClient(Control.MousePosition);
        bool hasPointerInside = panel1.ClientRectangle.Contains(mousePosition);
        if (!hasPointerInside)
        {
            // Your code ↓
            panel1.BackgroundImage = STUDIO2.Properties.Resources.buttonbackground;
        }
    }
