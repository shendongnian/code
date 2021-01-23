    `if (IsPostBack)
    {
        string ControlID = string.Empty;
        if (!String.IsNullOrEmpty(Request.Form["__EVENTTARGET"]))
        {
            ControlID = Request.Form["__EVENTTARGET"];
            Control postbackControl = Page.FindControl(ControlID);
        }
