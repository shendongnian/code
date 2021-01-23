    int j;
            for (j=i; j < dataGridView1.RowCount && y<e.MarginBounds.Bottom; j++)
            {
                e.Graphics.DrawString(e.MarginBounds.Bottom.ToString(), DefaultFont, Brushes.Black, new Point(100, y));
                e.Graphics.DrawString(dataGridView1.Rows[j].Cells["ProductName"].Value.ToString(), DefaultFont, Brushes.Black, new Point(35, y));
                e.Graphics.DrawString(dataGridView1.Rows[j].Cells["Desc"].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(220, y));
                e.Graphics.DrawString(dataGridView1.Rows[j].Cells["Quantity"].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(770, y));
                e.Graphics.DrawString(dataGridView1.Rows[j].Cells["UnitPrice"].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(620, y));
                e.Graphics.DrawString(dataGridView1.Rows[j].Cells["Tax"].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(670, y));
                e.Graphics.DrawString(dataGridView1.Rows[j].Cells["Total"].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(720, y));
                y = y + 20;
            }
            if (j < dataGridView1.RowCount)
            {
                e.HasMorePages = true;
                i=j;
            }
            else
            {
                e.HasMorePages = false;
                i = 0;
            }
