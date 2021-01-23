    [WebMethod]
    public static bool CheckIfNameExists(string Name)//error on this line
    {
        bool Result = false;
        try
        {
           Result = Creditor.CheckIfNameCreditorExists(Company.Current.CompanyID, Name) != "";
        }
        catch (Exception ex)
        {
        }
        return Result
    }
