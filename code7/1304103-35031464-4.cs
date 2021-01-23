    private void button5_Click(object sender, EventArgs e)
    {
        HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("input");
        int i = 10;
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("className")== "input-style1 psgn-name")
            {
                TextBox tb = Controls.Find("textBox" + i) as TextBox;
                i++;
                
                if(tb != null) {
                    tb.Text = link.GetAttribute("id");
                }
            }
        }
    }
