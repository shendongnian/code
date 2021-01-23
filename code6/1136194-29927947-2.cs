    bool btnUsedPressed = false;
    buttonUse.Click += new EventHandler(this.buttonUse_Click); // e.g. in the Form_Load() 
    // and then
    protected override void Form_Paint(PaintEventArgs e)
    {
        if (radioButtonColor.Checked == true && btnUsedPressed)
        {
            e.Graphics.DrawImage(Properties.Resources.colors, destRect, srcRect,GraphicsUnit.Pixel);
            graphicsPanel1.Invalidate();
        }
    }
    void buttonUse_Click(Object sender, EventArgs e)
    {
        btnUsedPressed = true;
    }
