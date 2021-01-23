    string url = "http://www.google.com";
    WebBrowser wb = new WebBrowser();
    wb.Navigate(new Uri(url));
    wb.DocumentCompleted += (s, e) =>
    {
        HtmlElementCollection elementcolls = wb.Document.GetElementsByTagName("img");
        foreach (HtmlElement elementcoll in elementcolls)
        {
            listBox1.Items.Add(elementcoll.GetAttribute("src"));
        }
    };
