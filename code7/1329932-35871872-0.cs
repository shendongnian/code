    VScrollBar vsbFeedGrid = null;
    // The vscrollbar index is 1 in this.dgvFeedItems.Controls but I loop in case it isnt always in that position
    foreach (Control control in this.dgvFeedItems.Controls)
    {
        if (control is VScrollBar)
        {
            vsbFeedGrid = (VScrollBar)control;
            break;
        }
    }
    if (vsbFeedGrid != null)
    {
        int intCurrentVPosition = vsbFeedGrid.Value;  // Store current scroll position
        DeleteItemFromFeedGrid(lngFeedItemID);  // Update datatable
        vsbFeedGrid.Enabled = true;             //Re-enable the vertical scrollbar
        if (intCurrentVPosition > vsbFeedGrid.Maximum)  //Re-position the vertical scrollbar
        {
            vsbFeedGrid.Value = vsbFeedGrid.Maximum;  // In case it was the last record deleted
        }
        else
        {
            vsbFeedGrid.Value = intCurrentVPosition;
        }
    }
