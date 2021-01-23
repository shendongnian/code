      public static void DataGridViewCellVisibility(DataGridViewCell cell, bool visible)
      {
            cell.Style = visible ?
                  new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) } :
                  new DataGridViewCellStyle { Padding = new Padding(cell.OwningColumn.Width, 0, 0, 0) };
      }
