        public string Groups { get; set; } // this will be my new attribute
        var groups = Groups.Split(',').ToList();
        
        var context = new PrincipalContext(ContextType.Domain,"myDomain");
        var userPrincipal = UserPrincipal.FindByIdentity(context,IdentityType.SamAccountName,httpContext.User.Identity.Name);
        
        foreach(var group in groups){ // will iterate the attribute and check if that user log is in that group
         if(userPrincipal.IsMemberOf(context, IdentityType.Name, group)){
                                return true;
         }
       }
