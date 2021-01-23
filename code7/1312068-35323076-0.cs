    private void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle r1 = dataGridView1.GetCellDisplayRectangle(4, -1, true);
        int w2 = dataGridView1.GetCellDisplayRectangle(3, -1, true).Width;
        int w3 = dataGridView1.GetCellDisplayRectangle(2, -1, true).Width;
        r1.X += 1;
        r1.Y += 1;
        r1.Width = r1.Width + w2 + w3;
        r1.Height = r1.Height / 2 - 2;
        e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);
        StringFormat format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;
        e.Graphics.DrawString("رياضيات", dataGridView1.ColumnHeadersDefaultCellStyle.Font,
            new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
    }
