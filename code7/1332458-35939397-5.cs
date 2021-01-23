    private void PrintFile(string fileName)
    {
        using (var wb = new WebBrowser())
        {
            wb.Navigate(fileName);
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            wb.Print();
        }
    }
