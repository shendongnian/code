    private void button5_Click(object sender, EventArgs e)
    {
        HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("input");
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("className")== "input-style1 psgn-name")
            {
                textBox10.Text += link.GetAttribute("id") + ",";
            }
        }
        
        // Remove last comma
        if(!string.IsNullOrWhiteSpace(textBox10.Text)){
            textBox10.Text = textBox10.Text.Substring(0, textBox10.Text.Length - 1);
        }
    }
