    using System.Web.Services;
    
    public static class HR
        {
            [WebMethod]
            public static int GetEmployeeCount(string department)
            {
                int count = 0;
                ...
                return count;
            }
        }
