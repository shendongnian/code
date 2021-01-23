    private void FormTLPTest_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Next)
        {
            int currentRow = 0;
            for (int y=0;y<tlp.RowCount;y++)
            {
                Control c = tlp.GetControlFromPosition(0, y);
                if (c.Location.Y >= 0)
                {
                    currentRow = y;
                    break;
                }
            }
            int nextRow = -1;
            if (e.KeyCode == Keys.PageUp)
                nextRow = currentRow - 1;
            else
                nextRow = currentRow + 1;
            if (nextRow < 0 || nextRow > tlp.RowCount - 1)
                return;
            Control nextTopControl = tlp.GetControlFromPosition(0, nextRow);
            tlp.ScrollControlIntoView(tlp.GetControlFromPosition(0, tlp.RowCount - 1));
            tlp.ScrollControlIntoView(nextTopControl);
        }
    }
