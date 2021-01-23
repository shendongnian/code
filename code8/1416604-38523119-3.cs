    [System.Web.Services.WebMethod]
    public static string NumPagination(string Num)
    {
        Page Pagination = new Page();
        Pagination.Session["Pagination"] = Num;
        return Num;
    }
    if (!string.IsNullOrEmpty(Session["Pagination"] as string))
    {
        string Select = "1";
        Select = Session["Pagination"].ToString();
        Session["Pagination"] = null;
    }
