    if (keyData == (Keys.Control | Keys.P))
    {
        PrintDocument();
    }
    private void drucken_Click(object sender, EventArgs e)
    {
        PrintDocument();
    }
    private void PrintDocument()
    {
        PrintDialog printDialog = new PrintDialog();
        PrintDocument printDocument = new PrintDocument();
        printDialog.Document = printDocument;
        printDocument.PrintPage += new PrintPageEventHandler  (PrintReceiptPage);
        DialogResult result = printDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            printDocument.Print();
        }
    }
