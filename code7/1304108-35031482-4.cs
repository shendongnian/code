    private void button5_Click(object sender, EventArgs e)
    {
        HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("input");
        List<String> results = new List<String>();
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("className")== "input-style1 psgn-name")
            {
                    results.Add(link.GetAttribute("id"));
            }
        }
        textbox10.Text = results[0];
        textbox11.Text = results[1]; etc....
    }
