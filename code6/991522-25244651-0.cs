    protected override void OnPaint(PaintEventArgs e)
    {
        var tempEvent = this.paintEvent;//To avoid race
        if (tempEvent != null)
        {
            e.Graphics.SetClip(clipRectangle);
            try
            {
                tempEvent(this, new PaintEventArgs(e.Graphics, new Rectangle(1, UpArrowImage.Height, this.Width - 2, (this.Height - DownArrowImage.Height - UpArrowImage.Height))));   
            }
            finally
            {
                e.Graphics.ResetClip();
            }
        }    
    }
