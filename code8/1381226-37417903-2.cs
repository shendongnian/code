    Padding GetCorrectionPadding(TableLayoutPanel TLP, int minimumPadding)
    {
        Control container = TLP.Parent;
        int minPad = minimumPadding;
        Rectangle netRect = TLP.ClientRectangle;
        netRect.Inflate(-minPad, -minPad);
        int w = netRect.Width / TLP.ColumnCount;
        int h = netRect.Height / TLP.RowCount;
        int deltaX = (netRect.Width - w * TLP.ColumnCount) / 2;
        int deltaY = (netRect.Height - h * TLP.RowCount) / 2;
        int OddX = (netRect.Width - w * TLP.ColumnCount) % 2;
        int OddY = (netRect.Height - h * TLP.RowCount) % 2;
        return new Padding(minPad + deltaX, minPad + deltaY,
                           minPad + deltaX + OddX, minPad + deltaY + OddY);
    }
