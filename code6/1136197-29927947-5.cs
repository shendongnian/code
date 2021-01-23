    bool btnUsePressed = false; // Declare a variable to track pressed button
    buttonUse.Click += new EventHandler(this.buttonUse_Click); // e.g. in the Form_Load() 
    // and then
    private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
    {
        // ... YOU CODE UP TO
        if (radioButtonColor.Checked == true && btnUsePressed)
        {
            e.Graphics.DrawImage(Properties.Resources.colors, destRect, srcRect,GraphicsUnit.Pixel);
            graphicsPanel1.Invalidate();
        }
        // ... YOU CODE AFTER
    }
    void buttonUse_Click(Object sender, EventArgs e)
    {
        if (btnUsePressed)
           btnUsePressed = false;
        else
        {
           btnUsePressed = true;
           graphicsPanel1.Refresh();
        }
    }
