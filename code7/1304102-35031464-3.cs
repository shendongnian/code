    private void button5_Click(object sender, EventArgs e)
    {
        HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("input");
        int i = 10;
        foreach (HtmlElement link in links)
        {
            if (link.GetAttribute("className")== "input-style1 psgn-name")
            {
                foreach(Control ctrl in Controls)
                {
                    if (ctrl is TextBox){
                        TextBox tb = (CheckBox)c;
                        if(tb.Name == "textBox" + i) {
                            i++;
                            tb.Text = link.GetAttribute("id");
                        }
                    }
                }
            }
        }
    }
