    string username = "YOUR_USERNAME";
    string password = "YOUR_PASSWORD";
    string siteUrl = "https://XXX.sharepoint.com";
    
    ClientContext context = new ClientContext(siteUrl);
    
    SecureString pass = new SecureString();
    foreach (char c in password.ToCharArray()) pass.AppendChar(c);
    context.Credentials = new SharePointOnlineCredentials(username, pass);
    
    Site site = context.Site;
    context.Load(site);
    context.ExecuteQuery();
    
    Web web = site.OpenWeb("YOUR_SUBSITE"); 
    context.Load(web);
    context.ExecuteQuery();
    
    List docLib = web.Lists.GetByTitle("YOUR_LIBRARY");
    context.Load(docLib);
    
    FileCreationInformation newFile = new FileCreationInformation();
    string filePath = @"YOUR_LOCAL_FILE";
    
    newFile.Content = System.IO.File.ReadAllBytes(filePath);
    newFile.Url = System.IO.Path.GetFileName(filePath);
    
    Microsoft.SharePoint.Client.File uploadFile = docLib.RootFolder.Files.Add(newFile);
    context.Load(uploadFile);
    context.ExecuteQuery();
