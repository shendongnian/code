        string[] CompaniesForUser()
        {
        string[] roles = new string[] { "CompanyA_Admin", "CompanyB_Admin", "CompanyA_Basic", "CompanyB_Basic" };  //System.Web.Security.Roles.GetRolesForUser();
        string[] companies = new string[100];
        int index = 0;
        foreach(string role in roles)
        {
            string cName =  role.Split('_')[0];
            
            //Only add new companies
            if (!companies.Contains(cName))
            {
                companies[index] = cName;
                
                //Testing
                Response.Write("Index : " + index + " - " + cName + "<br>");
                index++;
            }
        }
        return companies;
    }
