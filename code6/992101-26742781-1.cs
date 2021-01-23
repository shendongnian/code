    private void tsCboAddCharList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Cast the sender to the ToolStripComboBox type:
        ToolStripComboBox cmbAddCharList = (ToolStripComboBox)sender;
        // Cast its OwnerItem.Owner to the ContextMenuStrip type:
        ContextMenuStrip contextMenuStrip = (ContextMenuStrip)cmbAddCharList.OwnerItem.Owner;
        // Cast its SourceControl to the ListView type:
        ListView callingListV = (ListView)contextMenuStrip.SourceControl;
    }
