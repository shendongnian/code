    if (!IsPostBack)
    {
        Type page = this.Page.GetType();
        System.Web.UI.Control control = FindControl(page.BaseType.Name);
        ((System.Web.UI.HtmlControls.HtmlAnchor)control).Attributes.Remove("class");
        ((System.Web.UI.HtmlControls.HtmlAnchor)control).Attributes.Add("class", "active");
    }
 
