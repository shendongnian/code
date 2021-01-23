    ContentPlaceHolder cph = (ContentPlaceHolder)form.FindControl("cphTournamentDropdown");
    HtmlGenericControl genericControl = (HtmlGenericControl)cph.FindControl("ZZZ");
            
    for (int i = 0; i < 10; i++)
    {
        var item = new HtmlGenericControl("li");
        item.InnerText = i.ToString();
        genericControl.Controls.Add(item);
    }
