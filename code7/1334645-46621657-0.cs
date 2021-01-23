    private void DocumentComplete(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        _Timer.Start();
        if (yourBrowser.ReadyState != WebBrowserReadyState.Complete)
            return;
        parseWebbrowserDocumentPropertyFunc();
    }
    private void parseWebbrowserDocumentPropertyFunc()
    {
        _Timer.Stop();
        //something parse.....
    }
