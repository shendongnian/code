        static void ProcessListResult(object sender, GetListCompletedEventArgs e)
        {
            var proxy = sender as Contoso.Lists;
            var listName = e.UserState as string;
            var xmlDoc = new System.Xml.XmlDocument();
            var ndQuery = xmlDoc.CreateElement("Query");
            var ndViewFields = xmlDoc.CreateElement("ViewFields");
            var ndQueryOptions = xmlDoc.CreateElement("QueryOptions");
            proxy.GetListItemsAsync(listName, null, ndQuery, ndViewFields, null, ndQueryOptions, null);
            proxy.GetListItemsCompleted += ProcessListItemsResult;
        }
        static void ProcessListItemsResult(object sender, GetListItemsCompletedEventArgs e)
        {
            //omitted for clarity...
        }
 
