        UserCollection = new ObservableCollection<User>();
        
        public void FillUserList(string machineName,string groupName)
        {
            UserCollection.Clear();
            if (string.IsNullOrEmpty(machineName) || string.IsNullOrEmpty(groupName))
                return;
        
            using(var machineContext = new PrincipalContext(ContextType.Machine, machineName, null, ContextOptions.Negotiate)){
              var group = GroupPrincipal.FindByIdentity(machineContext, groupName);
        
              var members = group.GetMembers();
        
              foreach (var member in members)
              {
                 var user = new User { DisplayName = member.Name, UserId = member.SamAccountName };
                 UserCollection.Add(user);                
              }
    
             //try disposing the objects
             group.Dispose(); 
           }
        }
