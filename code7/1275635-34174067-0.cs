    protected void Page_Load(object sender, EventArgs e) {
        var li_1 = new HtmlGenericControl("li") {
            InnerText = "first item",
            ID = "li_1"
        };
        ctlTreeView_1.Controls.Add(li_1);
        var ul_2 = new HtmlGenericControl("ul") {
            ID = "ul_2"
        };
        li_1.Controls.Add(ul_2);
        var li_2_1 = new HtmlGenericControl("li") {
            InnerText = "first inner item",
            ID = "li_2_1"
        };
        ul_2.Controls.Add(li_2_1);
    }
