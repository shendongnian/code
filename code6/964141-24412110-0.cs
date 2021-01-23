            string username = "xxx@xxx.onmicrosoft.com";
            String pwd = "xxx#";
            ClientContext context = new ClientContext("https://xxx-my.sharepoint.com/personal/xxx_xxxinc_onmicrosoft_com/");
            SecureString password = new SecureString();
            foreach (char c in pwd.ToCharArray())
            {
                password.AppendChar(c);            }
            context.Credentials = new SharePointOnlineCredentials(username, password);
            //login in to SharePoint online
            context.ExecuteQuery();   
            //OneDrive is acctually a Document list
            List docs = context.Web.Lists.GetByTitle("Documents");
            context.ExecuteQuery();
            CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            ListItemCollection items = docs.GetItems(query);
            // Retrieve all items the document list
            context.Load(items);
            context.ExecuteQuery();
            foreach (ListItem listItem in items)
            {
                Console.WriteLine(listItem["Title"]);
            } 
