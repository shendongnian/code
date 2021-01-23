        private void butRefreshSelectedWorksheets_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Globals.ThisAddIn.RefreshWorksheetListings();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error [butRefreshSelectedWorksheets_Click]: " + ex);
            }
        }
