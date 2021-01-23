    // Screen code
     //========================== 
       partial void HelpScreen_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            // Use CompanyID in screens.
            int coID = Application.CompanyID;
        }
    //Application.cs code //===================
        // Application.cs in Client UserCode
        partial void Application_LoggedIn()
        {
            if (Application.Current.User.IsAuthenticated)
            {
                // Get your company ID here using a query that makes sense for your need.
                using (var ws = Application.Current.CreateDataWorkspace())
                {
                    string cUser = Application.Current.User.Name;
                    var contact = ws.ApplicationData.Contacts.Where(c => c.UserName == cUser).FirstOrDefault();
                    if (contact != null)
                        CompanyID = contact.Id;
                }
            }
        }
        
