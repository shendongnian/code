    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    HtmlWeb wb = new HtmlWeb()
    doc = wb.Load(TextBox2.Text)
    HtmlNodeCollection texts = doc.DocumentNode.SelectNode("//div[@class='text-conent']/p");
    string kq = "";
               foreach (var item in texts)
                   {
                       kq += item.InnerText + Environment.NewLine;
                   }
               richTextBox1.Text = kq;
