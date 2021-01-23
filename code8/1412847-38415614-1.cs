    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var listBox = sender as ListBox;
        var backBrush = Brushes.White;
        var textColor = Color.Black;
        var txt = listBox.GetItemText(listBox.Items[e.Index]);
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        {
            backBrush = Brushes.RoyalBlue;
            textColor = Color.Yellow;
        }
        e.Graphics.FillRectangle(backBrush, e.Bounds);
        TextRenderer.DrawText(e.Graphics, txt, listBox.Font, e.Bounds, textColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
    }
