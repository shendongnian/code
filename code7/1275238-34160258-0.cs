    ClientContext clientContext = new ClientContext("http://127.0.0.1");
            var oList = clientContext.Web.Lists.GetByTitle("TestList");
    
            CamlQuery camlQuery = new CamlQuery();
            ListItemCollection collListItem = oList.GetItems(camlQuery);
    
            clientContext.Load(
                collListItem,
                items => items.Include(
                item => item["Title"]));
    
            clientContext.ExecuteQuery();
    
            ArrayList itserv = new ArrayList();
            foreach (ListItem oListItem in collListItem)
            {
                itserv.Add(oListItem["Title"].ToString());
            }
