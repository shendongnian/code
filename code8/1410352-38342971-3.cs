    [System.Web.Services.WebMethod]
    public static AJAXResponse ChangePasswordWeb(string id)
    {
        string retVal = ChangePassword(id);
        var response = new AJAXResponse();
        if (retVal == "Password changed.")
            response.SuccessMessage = retVal;
        else
            response.ErrorMessage = retVal;
        return response;
    }
