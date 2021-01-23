    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("Column1", typeof(bool));
        dt.Rows.Add(false);
        dt.Rows.Add(true);
        this.dataGridView1.DataSource = dt;
        this.dataGridView1.CellPainting += dataGridView1_CellPainting;
    }
    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex >= 0)
        {
            var value = (bool?)e.FormattedValue;
            e.Paint(e.CellBounds, DataGridViewPaintParts.All &
                                    ~DataGridViewPaintParts.ContentForeground);
            var state = value.HasValue && value.Value ?
                RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
            var size = RadioButtonRenderer.GetGlyphSize(e.Graphics, state);
            var location = new Point((e.CellBounds.Width - size.Width) / 2,
                                        (e.CellBounds.Height - size.Height) / 2);
            location.Offset(e.CellBounds.Location);
            RadioButtonRenderer.DrawRadioButton(e.Graphics, location, state);
            e.Handled = true;
        }
    }
