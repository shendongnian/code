    <a class="dropdown-toggle" runat="server" id="WWW" ...
    ContentPlaceHolder cph = (ContentPlaceHolder)form.FindControl("cphTournamentDropdown");
    HtmlGenericControl genericControl = (HtmlGenericControl)cph.FindControl("ZZZ");
    HtmlAnchor cbo = (HtmlAnchor)genericControl.FindControl("WWW");
    for (int i = 0; i < 10; i++)
    {
        var item = new HtmlGenericControl("li");
        item.InnerText = i.ToString();
        cbo.Controls.Add(item);
    }
