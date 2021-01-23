    public static string GetLastTargetColumnValue(string sharePointSiteUrl, string sharePointListName, string targetColumnName)
            {
                string targetColumnValue = string.Empty;
                using (var clientContext = new ClientContext(sharePointSiteUrl))
                {
                    clientContext.Credentials = new NetworkCredential("userName", "password");
                    var list = clientContext.Web.Lists.GetByTitle(sharePointListName);
    
                    var field = list.Fields.GetByInternalNameOrTitle(targetColumnName);
                    var textField = clientContext.CastTo<FieldText>(field);
                    
                    var query = CamlQuery.CreateAllItemsQuery(100);
                    var items = list.GetItems(query);
    
                    clientContext.Load(textField);
                    clientContext.Load(items);
                    clientContext.ExecuteQuery();
    
                    var listItem = items.Last();
                    targetColumnValue = listItem[textField.InternalName] as string;
                }
                return targetColumnValue;
            }
