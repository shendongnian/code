    DataGridViewCellStyle style = new DataGridViewCellStyle();
    style.Font = new Font(dgvItems.Font.FontFamily, 12, FontStyle.Bold);
    foreach (DataGridViewRow row in dgvItems.Rows)
    {
       foreach (DataGridViewCell cell in row.Cells)
       {
          int result;
          bool isInt = Int32.TryParse(cell.Value.ToString(), out result);
          if (isInt && result > 1)
          {
            cell.Style = style;
          }
       }
    }
