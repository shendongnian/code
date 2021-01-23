    List<string> AllHTMLsToPrint = new List<string>();
    private int index = 0;
    PrintHelpPage(AllHTMLsToPrint[index]);
    
    private void PrintHelpPage(string strHTMLToPrint)
    {
        // Create a WebBrowser instance. 
        WebBrowser webBrowserForPrinting = new WebBrowser();
        // Add an event handler that prints the document after it loads.
        webBrowserForPrinting.DocumentCompleted +=
            new WebBrowserDocumentCompletedEventHandler(PrintDocument);
        // Set the Url property to load the document.
        webBrowserForPrinting.Url = new Uri(strHTMLToPrint);
    }
    private void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        // Print the document now that it is fully loaded.
        ((WebBrowser)sender).Print();
        
        if (index < AllHTMLsToPrint.Count -1)
        PrintHelpPage(AllHTMLsToPrint[++index]);
    }
