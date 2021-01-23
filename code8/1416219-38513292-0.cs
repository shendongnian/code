    public class SharepointRepository
        {
            public ListItemCollection ListTopN(string urlSite, string listName, bool ascending, string column, int rowLimit)
            {
                using (var context = new ClientContext(urlSite))
                {
                    context.Credentials = CredentialCache.DefaultCredentials;
                    List list = context.Web.Lists.GetByTitle(listName);
    
                    string myQuery = string.Format("<View><Query><OrderBy><FieldRef Name='{0}' Ascending='{1}' /></OrderBy></Query><RowLimit>{2}</RowLimit></View>", column, ascending.ToString(), rowLimit);
    
                    CamlQuery query = new CamlQuery();
                    query.ViewXml = myQuery;
    
                    ListItemCollection collection = list.GetItems(query);
    
                    context.Load(list);
                    context.Load(collection);
                    context.ExecuteQuery();
                    return collection;
                }
            }
    }
