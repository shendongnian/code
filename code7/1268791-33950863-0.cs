      private void AddMenuItem(string text, string link)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            menu.Controls.Add(li);
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", link);
            anchor.InnerText = text;
            li.Controls.Add(anchor);
        }
        AddMenuItem("text","link");
        AddMenuItem("text2","link2");
        AddMenuItem("text3","link3");
