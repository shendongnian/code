       using (ClientContext sourceContext = new ClientContext("Sharepoint Url"))
            {
                try
                {                    
                    sourceContext.ExecuteQuery();
                    List list = sourceContext.Web.Lists.GetByTitle("Test");
                    ListItemCollection itemColl = list.GetItems(CamlQuery.CreateAllItemsQuery());
                    sourceContext.Load(itemColl);
                    sourceContext.ExecuteQuery();
                }                
                catch (System.Net.WebException ex)
                {
                    if (ex.Message == "The remote server returned an error: (404) Not Found.")
                    {
                        Console.WriteLine("SharePoint not available");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }              
            }
