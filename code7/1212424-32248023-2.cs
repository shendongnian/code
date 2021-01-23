    [WebMethod]
    public static bool CheckIfNameExists(string Name)
    {
        bool res = false;
        try
        {
           // Check your string result if it's null or empty
           // and store the result in local variable
           res = !string.IsNullOrEmpty(Creditor.CheckIfNameCreditorExists(Company.Current.CompanyID, Name));
        }
        catch (Exception ex)
        {
            // Do your handling here
        }
        
        return res;
    }
