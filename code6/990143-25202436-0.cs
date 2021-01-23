    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == yourColumnIndex && String.IsNullOrEmpty((string)e.FormattedValue))
        {
            Graphics g = e.Graphics;
            TextBoxRenderer.DrawTextBox(g, e.CellBounds,
                System.Windows.Forms.VisualStyles.TextBoxState.Normal);
            e.Handled = true;
        }
    }
