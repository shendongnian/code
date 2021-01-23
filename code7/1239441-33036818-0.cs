    private void btnPrint_Click(object sender, EventArgs e)
    {
        PrintDialog.Document.PrintPage -= Print;
        PrintDialog.Document.PrintPage += Print;
        PrintDialog.Document.Print();
    }
    void Print(object sender, PrintPageEventArgs e)
    (
        //pass info
        PrintEvent(sender, e, PrintInfo)
    )
