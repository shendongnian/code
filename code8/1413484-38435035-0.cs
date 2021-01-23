    private void startDownload()
    {
                action = "step1";
                infoLabel5.Text = "Download started on series: " + series;
                infoLabel5.ForeColor = Color.Black;
                browser.ScriptErrorsSuppressed = true;
                browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browserCompleted);
                browser.Navigate("http://www.anilinkz.tv");
                browserProgress.Increment(10);
    }
    private void browserCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
                if (action == "step1")
                {
                    downloadStep1();
                }
    }
    private void downloadStep1()
    {
                action = null;
                infoLabel5.Text = "Download started on series: " + series;
                infoLabel5.ForeColor = Color.Black;
                browserProgress.Increment(5);
                var elements = browser.Document.GetElementsByTagName("input");
                foreach (HtmlElement element in elements)
                {
                    if (element.GetAttribute("classname") == "query")
                    {
                        element.SetAttribute("value", series);
                        downloadStep2();
                    }
                }
    }
    private void downloadStep2()
    {
                infoLabel5.Text = "Download started on series: " + series;
                infoLabel5.ForeColor = Color.Black;
                browserProgress.Increment(5);
                var elements = browser.Document.GetElementsByTagName("input");
                foreach (HtmlElement element in elements)
                {
                    if (element.GetAttribute("classname") == "searchbtn")
                    {
                        element.InvokeMember("click");
                    }
                }
    }
