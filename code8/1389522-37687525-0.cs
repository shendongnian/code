    private void btnPrintListDetail_Click(object sender, EventArgs e)
    {
        //Open the print dialog
        PrintDialog printDialog = new PrintDialog();
        printDialog.Document = printDocDetail;
        printDialog.UseEXDialog = true;
        
        //Get the document
        if (DialogResult.OK == printDialog.ShowDialog() && tabControl.SelectedIndex > -1)
        {
            foreach (DataGridView currentGridView in tabControl.SelectedTab.Controls.OfType<DataGridView>())
            {
                                    
                rows = currentGridView.Rows;
                page = 0;
                printDocDetail.DocumentName = "Contact List Detailed";
                printDocDetail.Print();
            }
           
        }
    }
