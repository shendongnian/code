    private void Print()
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
   
