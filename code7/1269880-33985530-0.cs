    int d= 10;
    private void timer1_Tick(object sender, EventArgs e)
    {
        //Reverse the direction of move
        if(panel1.Left==0 || panel1.Right==this.ClientRectangle.Width)
            d*=-1;
        if(movement>0)
            panel1.Left = Math.Min(panel1.Left + d, this.ClientRectangle.Width - panel1.Width);
        else
            panel1.Left = Math.Max(panel1.Left + d, 0);
    }
