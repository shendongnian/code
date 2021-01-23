        int columnIndex = -1;
      
        foreach (DataControlField col in grid.Columns)
        {
            if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
            {
                columnIndex = grid.Columns.IndexOf(col);
            }
        }
