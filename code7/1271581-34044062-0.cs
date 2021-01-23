    static void Main(string[] args)
        {
            wb = new WebBrowser();
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.Navigate("http://justicecourts.maricopa.gov/findacase/casehistory.aspx");
            while (!completed)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
           //wait even more
           for (int i = 0; i < 6; i++)
            {
                Application.DoEvents();
                Thread.Sleep(1000);
            }
            Console.Write("\n\nDone with it!\n\n");
            Console.ReadLine();
    
    
        }
