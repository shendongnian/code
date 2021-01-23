    /// <summary>
    /// Handles the MouseDown event of the grdSearch control. On a mousedown the click co-ordinates
    ///  is set.  This method is used to determine whether you have clicked on a gridrow cell in the method above
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private void grdSearch_MouseDown(object sender, MouseEventArgs e)
    {
        MLastX = e.X;
        MLastY = e.Y;
    }
