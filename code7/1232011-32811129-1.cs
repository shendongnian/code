    foreach (ToolStripItem mi in settingsToolStrip.Items) {
        ToolStripControlHost item = mi as ToolStripControlHost; 
        if (item != null) {
            if (item.Control is CheckBox) {
                // put your code here that checks all but the one that was clicked.
                ((CheckBox)item.Control).Checked = false;
            }
        }
    }
