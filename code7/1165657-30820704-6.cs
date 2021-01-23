    private void Form1_Load(object sender, EventArgs e)
    {
        DGV.Rows.Add(12);
        for( int i = 0; i< DGV.Rows.Count; i++)
        {
            DGV[0, i].Value = i;
            DGV[1, i].Value = R.Next(1000);
            DGV[2, i].Value = rights[R.Next(rights.Count)];
            DGV[3, i].ReadOnly = true;
        }
    }
    List<string> rights = new List<string> 
      { "SIDU", "SID-", "SI-U", "S-DU", "SI--", "S--U", "S-D-", "S---" };
    Dictionary<char, string> rightsTexts = new Dictionary<char, string> 
      { { 'S', "Select" }, { 'I', "Insert" }, { 'D', "Delete" }, { 'U', "Update" } };
    Random R = new Random(1);
    private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 3 && e.RowIndex >= 0)
        {
            string r = DGV[2,e.RowIndex].Value.ToString();
            StringFormat format = new StringFormat()
            { LineAlignment = StringAlignment.Center,  Alignment = StringAlignment.Center};
            int w = e.CellBounds.Width / 4;
            int y = e.CellBounds.Y + 1;
            int h = e.CellBounds.Height - 2;
            e.PaintBackground(e.CellBounds, false);
            for (int i = 0; i < 4; i++)
            {
               int x = e.CellBounds.X + i * w;
               Rectangle rect = new Rectangle(x, y, w, h);
               ControlPaint.DrawButton(e.Graphics, rect, ButtonState.Normal);
               if (rightsTexts.ContainsKey(r[i])) 
                   e.Graphics.DrawString(rightsTexts[r[i]], DGV.Font,
                                         SystemBrushes.WindowText, rect ,format );
            }
            e.Handled = true;
        }
    }
    private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex == 3 && e.RowIndex >= 0)
        {
            DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex];
            int w = cell.Size.Width;
            int buttonIndex = e.X * 4 / w;
            Text = rightsTexts.ElementAt(buttonIndex).Value;
        }
    }
