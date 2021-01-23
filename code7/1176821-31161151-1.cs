    [System.Web.Services.WebMethod]
    public static void Proposal(string GetProposal, string ProductName, string ProductID)
    {
        
         HttpContext.Current.Response.Redirect("MyPage");
        
    }
