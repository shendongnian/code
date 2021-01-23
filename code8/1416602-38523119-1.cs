    [System.Web.Services.WebMethod]
    public static string NumPagination(string Num)
    {
        Page Pagination = new Page();
        Pagination.Session["Pagination"] = Num;
        return Num;
    }
