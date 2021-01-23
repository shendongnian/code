     HtmlDocument doc = webBrowser1.Document;
        HtmlElement HTMLControl2 = doc.GetElementById("searchInput");
    
        if (HTMLControl2 != null)
        {
            // HTMLControl2.Style = "display: none";
            HTMLControl2.InnerText = textBox1.Text;
                     SendKeys.Send("{ENTER}");
                    textBox1.Focus();
                   HTMLControl2.Focus();
                    HTMLControl2.InnerText = textBox1.Text;
                  SendKeys.Send("{ENTER}");
                   textBox1.Focus();
                  HTMLControl2.Focus();
    }
