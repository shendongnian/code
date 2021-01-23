    public class OnItemCreating
      {
        public void OnItemCreating(object sender, EventArgs args)
        {
          using (new SecurityDisabler())
          {
            ItemCreatingEventArgs arg = Event.ExtractParameter(args, 0) as ItemCreatingEventArgs;
    
             if (arg .Item != null)
                {
                    var item = arg .Item;
    
                    if (item.Parent != null)
                    {
                        //see if the item is being placed under a Navigation Item type or under the Navigation folder
                        if (item.Parent.TemplateName == "Navigation Item" || item.ParentID.ToString() == "{6ED240C9-1B69-48E2-9FD9-6C45CD8ABE63}")
                        {
                            if (item.TemplateName != "Navigation Item")
                            {
                                using (new Sitecore.SecurityModel.SecurityDisabler())
                                {
                                    
                                    ((SitecoreEventArgs)args).Result.Cancel = true;
                                    SheerResponse.Alert("Sorry, you can only add items based on the \"Navigation Item\" template here");
    
                                }
    
                            }
                        }
                    }
    
                }
          }
        }
      }
