    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetSimpleControl(string usercontrolName)
    {
        Page page = new Page();
        page.Culture = "en";
        page.UICulture = "en";
        UserControl ctl = (UserControl)page.LoadControl(usercontrolName);
        page.Controls.Add(ctl);
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.Execute(page, writer, false);
        return writer.ToString();
}
