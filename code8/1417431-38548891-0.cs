    private void Form1_DoubleClick(object sender, EventArgs e)
    {
        if ((this.Height == Screen.FromControl(this).WorkingArea.Height) && (this.Width == Screen.FromControl(this).WorkingArea.Width))
        {
            this.Width = 534;
            this.Height = 600;
            CenterToScreen();
        }
        else
        {
            this.Height = Screen.FromControl(this).WorkingArea.Height;
            this.Width = Screen.FromControl(this).WorkingArea.Width;
            this.Location = Screen.FromControl(this).WorkingArea.Location;
        }  
    }
