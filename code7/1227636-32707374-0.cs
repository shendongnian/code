    private void imageBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        this.imageBrowser.DocumentCompleted -= imageBrowser_DocumentCompleted;
        try
        {
            Populate().ContinueWith((_) =>
            {
                var buttons = imageBrowser.Document.GetElementsByTagName("button");
                foreach (HtmlElement button in buttons)
                {
                    if (button.InnerText == "done")
                    {
                    button.InvokeMember("click");
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        catch
        {
            //debug
        }
    }
