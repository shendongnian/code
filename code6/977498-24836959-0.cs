    private bool isLeft = true;
    private void SwapPosition()
    {
       isLeft = !isLeft;
       foreach (Control cnt in this.Controls)
           SwapPosition(cnt);
    }
    private void SwapPosition(Control cnt)
    {
        cnt.Left = cnt.Parent.Width - (cnt.Left + cnt.Width);
        ///Assign other properties also
        ///ie. cnt.RightToLeft = !isLeft
        ///if (isLeft) then NormalFont else Hebrew or any
        foreach (Controls cntChild in cnt.Controls)
            RightToLeft(cntChild);
    }
