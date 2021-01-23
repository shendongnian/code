    // I suppose your column is at index 0
    var c = this.dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
    c.Width = c.Items.Cast<Object>().Select(x => x.ToString())
        .Max(x => TextRenderer.MeasureText(x, c.InheritedStyle.Font,
            Size.Empty, TextFormatFlags.Default).Width);
