    //Control 'Content_ctlDisplayIssues_gvIssues' of type 'GridView' must be placed inside a form tag with runat=server.
    System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
    parentControl.Controls.Add(form);
    form.Controls.Add(gv);
    form.RenderControl(htw);
