     private string gvGetVal(GridView gvGrid, string sHeaderText)
        {
            GridViewRow row = gvGrid.SelectedRow;
            int iCol = gvGetColumn(gvGrid, sHeaderText);
            return row.Cells[iCol].Text;
    
        }
    
        private int gvGetColumn(GridView gvGrid, string sHeaderText)
        {
            int iRetVal = -1;
            for (int i = 0; i < gvGrid.Columns.Count; i++)
            {
                if (gvGrid.Columns[i].HeaderText.ToLower().Trim() == sHeaderText.ToLower().Trim())
                {
                    iRetVal = ((gvGrid.AutoGenerateSelectButton == true) ? i + 1 : i);
                }
            }
            return iRetVal;
        }
