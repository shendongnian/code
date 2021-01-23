	    protected void OnItemCreated(object sender, EventArgs args)
        {
            if (args == null)
            {
                return;
            }
            var parameters = Event.ExtractParameters(args);
            var item = ((ItemCreatedEventArgs)parameters[0]).Item;
            if (item == null)
            { 
				return; 
			}
            var user = Sitecore.Context.User;
            
            var accessRules = item.Security.GetAccessRules();
  
            accessRules.Helper.AddAccessPermission(user,
               AccessRight.ItemRead,
               PropagationType.Any,
               AccessPermission.Allow);
            accessRules.Helper.AddAccessPermission(user,
               AccessRight.ItemWrite,
               PropagationType.Any,
               AccessPermission.Allow);
            
            item.Editing.BeginEdit();
            item.Security.SetAccessRules(accessRules);
            item.Editing.EndEdit();
        }
