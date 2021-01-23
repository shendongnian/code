    private void grdOtherItemsInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
    {
        UltraGridBand band;
        try
        {
            band = e.Layout.Bands[0];
    
            band.ColHeaderLines = 2;
    
            // Rows collection of the grid contains the rows in Band[0] or the top level of GroupByRows
            foreach (UltraGridRow row in this.grdOtherItemsInfo.Rows)
            {
                // Check if the row is DataRow, otherwise you will get an exception when you call Cell property of not data row
                if (row.IsDataRow)
                {
                    // Cashing the cell so not taking it twice
                    UltraGridCell cell = row.Cells[OtherItemStoreRequisitionForBatchChild.IsAutoDispense];
                    if (cell.Value.ToString() == "1")
                    {
                        // Setting the cells' Activation will set each cell its own activation
                        // If you set it to the column all the cells in the column will have same activation
                        cell.Activation = Activation.ActivateOnly;
                        row.Cells[OtherItemStoreRequisitionForBatchChild.IndentedUOM].Activation = Activation.ActivateOnly;
                        row.Cells[OtherItemStoreRequisitionForBatchChild.IndentedQty].Activation = Activation.ActivateOnly;
                    }
                }
            }
        }
        catch(Exception ex)
        {
            // TODO: ...
        }
    }
