    buttonUse.Click += new EventHandler(this.buttonUse_Click); // e.g. in the Form_Load() 
    // and then
    void buttonUse_Click(Object sender, EventArgs e)
    {
        if (radioButtonColor.Checked == true)
        {
            e.Graphics.DrawImage(Properties.Resources.colors, destRect, srcRect,GraphicsUnit.Pixel);
            graphicsPanel1.Invalidate();
        }
    }
