    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        HtmlDocument doc = webBrowser1.Document;
        HtmlElement HTMLControl2 = doc.GetElementById("searchInput");
        if (HTMLControl2 != null)
        {
            // HTMLControl2.Style = "display: none";
            HTMLControl2.InnerText = textBox1.Text;
            HTMLControl2.Focus();
            SendKeys.SendWait("{ENTER}");
            textBox1.Focus();
        }
    }
