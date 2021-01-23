    string searchlink = "";
    private void inkGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (inkGridView.SelectedCells.Count > 0)
            {
                int selectedrowindex = inkGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = inkGridView.Rows[selectedrowindex];
                searchlink = Convert.ToString(selectedRow.Cells["tonerInkDataGridViewTextBoxColumn"].Value);
            }
        }
        private void orderbutton_Click(object sender, EventArgs e)
        {
            string link;
            
            link = "http://store.tindallsb2b.co.uk/storefront/evolution_ProductResults.html?strSearch=" + searchlink;
            webBrowser.Url = new Uri(link);
        }
