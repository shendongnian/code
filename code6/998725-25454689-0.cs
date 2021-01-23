    void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        if (gridPSR.ClientRectangle.Contains(e.Location))
        {
            gridPSR.Enabled = true;
        }
    }
