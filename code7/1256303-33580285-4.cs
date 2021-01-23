    [WebMethod]
    public static void ClearSession()
    {
        if (Session["myVar"] != null)
        {
            Session.Remove("myVar");
        }
    }
