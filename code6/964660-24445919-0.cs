    ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
    Panel panel = (Panel)cph.FindControl("TablePanel");
    System.Web.UI.HtmlControls.HtmlTable table = (System.Web.UI.HtmlControls.HtmlTable)panel.FindControl("TableCheckBox");
    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)table.FindControl(chkboxbit);
    if (cb != null)
    {
        if (cb.Checked == true)
        cb.Checked = false;
    }
