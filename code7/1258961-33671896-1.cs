        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentPageName = "blank.html";
            var menuItemsList = new Dictionary<string, string>()
            {
                {"invoice.html", " Lockscreen"},
                {"lockscreen.html", " Lockscreen"},
                {"blank.html", " Blank"}
            };
            foreach (var item in menuItemsList)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl ianchor = new HtmlGenericControl("a");
                ianchor.Attributes.Add("href", item.Key);
                if (CurrentPageName == item.Key)
                {
                    ianchor.Attributes.Add("class", "active");
                }
                HtmlGenericControl i = new HtmlGenericControl("i");
                i.Attributes.Add("class", "fa fa-circle-o");
                ianchor.InnerText = item.Value;
                ianchor.Controls.AddAt(0, i);
                li.Controls.Add(ianchor);
                myMenu.Controls.Add(li);
            }
        }
