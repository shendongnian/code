     try
    {
    
        //Get the name of the sharepoint list that needs to be updated from settings 
        var ListName = ConfigurationManager.AppSettings[Constants.SettingsConstants.SPLaunchQueList];
        var TargetSiteToUpdate =  "URL TO THE SITE YOUR TRYING TO UPDATE"; 
        //Get the sharepoint context from session 
        var spContext = <SOME HOW CREATE YOUR CONTEXT> 
        //Lets create a client context from the current sharepoint context to the target site 
        //NOTE this requires the application to HAVE Tenant level permission, it must be trusted by
        //the farm admin 
        using (var spClientContext = CreateRemoteSharePointContext(TargetSiteToUpdate, spContext))
        {
            
            //Get the current Web (Sharepoint Web) from the client context 
            var web = spClientContext.Web;
            //Load all the webs properties including title , url all the lists and get the subwebs if any as well 
            spClientContext.Load(web, x => x.Title, x => x.Url, x => x.Lists, x => x.Webs.Include(w => w.Title, w => w.Url));
            spClientContext.ExecuteQuery();
            //Lets grab the list that needs to be updated 
            SP.List OrgList = web.Lists.GetByTitle(ListName);
            //Construct a caml query Where the groupID of the SQL Server record is the same 
            //as the list GroupID 
            var caml = new Caml<DetailParts>().Where(o => o.GroupID == updateRecord.GroupID);
            CamlQuery camlQuery = new CamlQuery();
            camlQuery.ViewXml = caml.ToString();
            //Load the CAML query 
            ListItemCollection Rows = OrgList.GetItems(camlQuery);
            spClientContext.Load(Rows);
            spClientContext.ExecuteQuery();
            //The CAML Query should only return one row because GroupID should be UNQIUE 
            //however due to how sharepoint returns list data we are forcing the first value 
            //here 
            ListItem RowToUpdate = Rows[0];
            //Get a list of sharepoint columns that match the local detail parts 
            var ColumnsToUpdate = GetSharePointColumns(typeof(DetailParts));
    		
    		 RowToUpDate["SomeColumn"] = "YOUR NEW VALUE"; 
                
             RowToUpdate.Update();
             //Commit the changes 
             spClientContext.ExecuteQuery();
            }
        }
    
    }
    catch (Exception ex)
    {
        //Log any exception and then throw to the caller 
        logger.Error("Sharepoint exception", ex);
    }
