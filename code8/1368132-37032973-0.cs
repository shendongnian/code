        /// <summary>
        /// Will list out all the items within a Site, conduct a search and delete the item when found.
        /// </summary>
        /// <param name="sFileName"></param>
        /// <param name="sFldrLoc"></param>
        public static void DeleteAFile(string sFileName, string sFldrLoc)
        {
            ClientContext clientContext = new ClientContext(siteURL);
            Web web = clientContext.Web;
            ListCollection collList = web.Lists;
            List oList = collList.GetByTitle(sFldrLoc);
            CamlQuery query = new CamlQuery();
            query.ViewXml = "<View><Query><Where><Leq>" +
                "<FieldRef Name='ID'/><Value Type='Number'>100</Value>" +
                "</Leq></Where></Query><RowLimit>50</RowLimit></View>";
            ListItemCollection collListItem = oList.GetItems(query);
            clientContext.Load(collListItem,
                items => items.IncludeWithDefaultProperties(
                    item => item.DisplayName));
            clientContext.ExecuteQuery();
            foreach (ListItem listitem in collListItem)
            {
                if (listitem.DisplayName.Equals(sFileName))
                {
                    listitem.DeleteObject();
                    clientContext.ExecuteQuery();
                    Console.WriteLine("{0}, has been deleted sucessfully!", listitem.DisplayName);
                }
            }
        }
