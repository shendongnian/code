    //Show available moves
    Control[] lCurrent = PnlBoard.Controls.Find("pnl" + CurrentPlauer, true);
    Panel Current = null;
    System.Drawing.Point CurrentLoc = new System.Drawing.Point(0, 0);
    foreach (Control c in lCurrent)
    {
        Current = c as Panel;
        CurrentLoc = new System.Drawing.Point(c.Location.X, c.Location.Y);
    }
