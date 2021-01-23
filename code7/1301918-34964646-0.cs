    toolStripDropDownButton1.DropDown.Closing += toolStripDropDownButton1_Closing;
    private void toolStripDropDownButton1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
    {
        if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
        {
            e.Cancel = true;
        }
    }
