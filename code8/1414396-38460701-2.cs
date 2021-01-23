    Private Sub SwapControls(aTableLayoutControl As TableLayoutPanel, firstControl As Control, secondControl As Control)
        aTableLayoutControl.Controls.Remove(firstControl)
        aTableLayoutControl.Controls.Remove(secondControl)
        aTableLayoutControl.Controls.Add(secondControl)
        aTableLayoutControl.Controls.Add(firstControl)
    End Sub
