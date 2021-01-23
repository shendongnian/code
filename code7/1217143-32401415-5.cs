    private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        // Start at the beginning of the text
        firstCharOnPage = 0;
    }
    
    private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        // Clean up cached information
        richTextBoxEx1.FormatRangeDone();
    }
    
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        firstCharOnPage = richTextBoxEx1.FormatRange(false, e, firstCharOnPage, richTextBoxEx1.TextLength);
        // check if there are more pages to print
        if (firstCharOnPage < richTextBoxEx1.TextLength)
            e.HasMorePages = true;
        else
            e.HasMorePages = false;
    }
    private void printToolStripButton_Click(object sender, EventArgs e)
    {
        //Print the contents here
        printDocument1.Print();
    }
