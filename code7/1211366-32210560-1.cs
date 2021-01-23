    public string Test(string msg, WebBrowser WB)
    {
        return WB.Document.InvokeScript
                            ("Test", new String[] { msg });
    }
