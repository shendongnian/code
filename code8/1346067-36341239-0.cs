    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
    protected override void OnMouseClick(MouseEventArgs e)
    {
        var centerX = Left + Width/2.0;
        var centerY = Top + Height/2.0;
        var dist = (e.X - centerX)*(e.X - centerX) + (e.Y - centerY)*(e.Y - centerY);
        if(dist <= (radius*radius))
        {
            base.OnMouseClick(e);
        }
    }
