     /// <summary>
        /// Opens the object inspector
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">args</param>
        private void inspectorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Get the payload
                SectionDataTreeListMenuItemPayload payload = (sender as ToolStripMenuItem).Tag as SectionDataTreeListMenuItemPayload;
    
                if (payload == null || payload.DataRow == null)
                    return;
    
                using (frmInspector frmInspector = new frmInspector(payload.DataRow))
                    frmInspector.ShowDialog();
            }
            catch (Exception ex)
            {
                UIMessage.DisplayError(ex);
            }
        }
