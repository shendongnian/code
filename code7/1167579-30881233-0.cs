                // Url to site
                string url = "https://your.sharepoint.com";
                // get context for that Url
                var ctx = new ClientContext(url);
                // Provide credentials 
                // (Might be able to skip this if the server is on prem and your 
                // AD user has permissions to access the library)
                var password = new SecureString();
                foreach (var c in "your_password".ToCharArray())
                    password.AppendChar(c);
                ctx.Credentials = 
                    new SharePointOnlineCredentials("login@your.onmicrosoft.com", password);
                
                // get the library
                var list = ctx.Web.GetList("/Shared%20Documents/");
                // Empty query to get all items
                var listItems = list.GetItems(new CamlQuery());
                
                // Load all items and use Include to specify what properties
                // we want to be able to access
                ctx.Load(listItems, 
                    items => items.Include(
                        item => item["Created"], 
                        item => item.File));
                // Execute the query
                ctx.ExecuteQuery();
                // Just to show you we have all the items now
                foreach (var item in listItems)
                {
                    Console.WriteLine("{0} - {1}", 
                            item["Created"], 
                            item.File.ServerRelativeUrl);
                }
                // Orderby something and take one
                var fileInfo = listItems
                    .OrderBy(x => x.File.Name)
                    .Take(1)
                    .FirstOrDefault();
                if (fileInfo != null)
                {
                    // Open file
                    var fileInformation = 
                        File.OpenBinaryDirect(ctx, fileInfo.File.ServerRelativeUrl);
                    // Save File to c:\temp
                    using (var fileStream = 
                        new FileStream(@"c:\temp\" + fileInfo.File.Name, FileMode.Create))
                        fileInformation.Stream.CopyTo(fileStream);
                }
