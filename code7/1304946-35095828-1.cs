    public void AddUserToDMSite(string useremail, string securityGroupName, Web aWeb)
        {
     GroupCollection collGroup = aWeb.SiteGroups;
     Group oGroup1 = collGroup.GetByName("UserList");
     Group oGroup2 = collGroup.GetByName(securityGroupName);
     UserCollection oUserCollection1 = oGroup1.Users;
     UserCollection oUserCollection2 = oGroup2.Users;
     SPContext.Load(oUserCollection1);
     SPContext.Load(oUserCollection2);
     SPContext.ExecuteQuery();
     var uname = oGroup1.Users.GetByEmail(useremail);
     var userCheck = oUserCollection2.Where(u => u.Email == useremail).FirstOrDefault();
     if (userCheck == null)
     {
          Microsoft.SharePoint.Client.User oUser2 = oGroup2.Users.AddUser(uname);
     }
     SPContext.ExecuteQuery(); 
     }
