    Control nextControl;
    if (e.KeyCode == Keys.Enter)
    {     
        nextControl = GetNextControl(ActiveControl, !e.Shift);
        if (nextControl == null)
        {
            nextControl = GetNextControl(null, true);
        }
        nextControl.Focus();
        TextBox box = nextControl as TextBox;
        if (box != null)
            box.Select(box.Text.Length, 0);
        e.SuppressKeyPress = true;
    }
