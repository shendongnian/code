    EmployeeService prxy = new EmployeeService();
    prxy.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["UserName"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Password"].ToString(), "System.Configuration.ConfigurationManager.AppSettings["YourDomain"].ToString()");
     //while debug, prxy.UseDefaultCredentials= false here
    //My soap extension gets executed and resets credentials.
    prxy.GetEmployee(empId);
