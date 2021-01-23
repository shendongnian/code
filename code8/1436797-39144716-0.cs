        ClientContext clientContext = new ClientContext("http://Servername/");
        List sharedDocumentsList = clientContext.Web.Lists.GetByTitle("Shared Documents");
        CamlQuery camlQuery = new CamlQuery();
        camlQuery.ViewXml =
            @"<View Scope='Recursive' />";
        ClientOM.ListItemCollection listItems =
            sharedDocumentsList.GetItems(camlQuery);
        clientContext.Load(listItems);
        clientContext.ExecuteQuery();
        foreach (var item in listItems)
        {
        }
