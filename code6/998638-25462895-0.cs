    private List<Label> printLabels;    
    private PrintDocument pd;
    
    private void PrintButton_Click(object sender, RoutedEventArgs e)
    {
       // save the labels to a temporary list
       printLabels = new List<Label>(labels);
       // start the printing
       pd.Print("Test Print");
    }
    private void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        // print the first element from the temporary list
        Label labelToPrint = printLabels.First();
    
        var printpage = new LabelPrint();
        printpage.DataContext = new LabelPrintViewModel(labelToPrint);
        e.PageVisual = printpage;
    
        printLabels.Remove(labelToPrint);
    
        // continue printing if there's still any labels left
        e.HasMorePages = printLabels.Any();
    }
