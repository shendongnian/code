       public class Users
            {
                public string username { get; set; }
                public string mail { get; set; }
                public string sn { get; set; }
                public string givenName { get; set; }
                public string title { get; set; }
                public string department { get; set; }
                public string mobile { get; set; }
              
               
            }
    
    
    
      try
            {
                List<Users> lstADUsers = new List<Users>();
                string DomainPath = "";
                DirectoryEntry searchRoot = new DirectoryEntry(DomainPath); 
                DirectorySearcher search = new DirectorySearcher(searchRoot);
                search.Filter = "(&(objectClass=user)(objectCategory=person))";
                search.PropertiesToLoad.Add("username");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("sn");
                search.PropertiesToLoad.Add("givenName");
                  search.PropertiesToLoad.Add("title");
                search.PropertiesToLoad.Add("department");
                search.PropertiesToLoad.Add("mobile");
        
                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        string UserNameEmailString = string.Empty;
                        result = resultCol[counter];
                        if (result.Properties.Contains("samaccountname") && 
                                 result.Properties.Contains("mail") && 
                            result.Properties.Contains("displayname"))
                        {
                            Users objSurveyUsers = new Users();
                            objSurveyUsers.username = (String)result.Properties["username"][0];
                            objSurveyUsers.mail = (String)result.Properties["mail"][0];
                            objSurveyUsers.sn = (String)result.Properties["sn"][0];
                            objSurveyUsers.givenName = (String)result.Properties["givenName"][0];
                            objSurveyUsers.title = (String)result.Properties["title"][0];
                            objSurveyUsers.department = (String)result.Properties["department"][0];
                            objSurveyUsers.mobile = (String)result.Properties["mobile"][0];
                            lstADUsers.Add(objSurveyUsers);
                        }
                    }
                }
