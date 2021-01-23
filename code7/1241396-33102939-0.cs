    private void buildHtmlTableString(List<Week> w)
    {
        var sb = new System.Text.StringBuilder();
        foreach (Week element in w)
        {
            sb.Append("<tr>");
            sb.AppendFormat("<td> Week {0}</td>", element.weekNumber);
            sb.AppendFormat("<td>{0} €</td>", element.1);
            ...
            sb.AppendFormat("<td>{0} €</td>", element.10);
            sb.Append("<td>");
            myPlaceholder.Controls.Add(new System.Web.UI.WebControls.Literal(sb.ToString()));
            sb.Length = 0;
            var imgBtn = new System.Web.UI.WebControls.ImageButton
            {
                ID = element.1.ToString(),
                Width = new System.Web.UI.WebControls.Unit(20),
                Height = new System.Web.UI.WebControls.Unit(20)
            };
            imgBtn.Click += new System.Web.UI.ImageClickEventHandler(text_Click);
            myPlaceholder.Controls.Add(imgBtn);
            sb.Length = 0;
            myPlaceholder.Controls.Add(new System.Web.UI.WebControls.Literal("</td></tr>");
        }
    }
