    int counter = 0;
    int a = Convert.ToInt32(row.Cells[2].Value);
    int b = Convert.ToInt32(row.Cells[3].Value);
    foreach (DataGridViewRow row in dgvArticleStockInfo.Rows)
    {
         if (a <= b)
         {
             row.DefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144);
             panel1.BackColor = Color.FromArgb(144, 238, 144);
             counter++;
         }
         else
         {
             row.DefaultCellStyle.BackColor = Color.FromArgb(255,106,106);
             panel2.BackColor = Color.FromArgb(255,106,106);
         }
    }
