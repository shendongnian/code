    private void tsCboAddCharList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Cast the sender to the ToolStripComboBox type:
        ToolStripComboBox cmbAddCharList = sender as ToolStripComboBox;
        // Return if failed:
        if (cmbAddCharList == null)
            return;
        // Cast its OwnerItem.Owner to the ContextMenuStrip type:
        ContextMenuStrip contextMenuStrip = cmbAddCharList.OwnerItem.Owner as ContextMenuStrip;
        // Return if failed:
        if (contextMenuStrip == null)
            return;
        // Cast its SourceControl to the ListView type:
        ListView callingListV = contextMenuStrip.SourceControl as ListView;
        // Note: it could be null if the SourceControl cannot be casted the type ListView.
    }
