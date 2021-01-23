    // Creates a new instance of the Tree provider
    TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);
 
    // Gets the current site's root "/" page, which will serve as the parent page
    TreeNode parentPage = tree.SelectSingleNode(SiteContext.CurrentSiteName, "/", "en-us");
 
    if (parentPage != null)
    {
    // Creates a new page of the "CMS.MenuItem" page type
    TreeNode newPage = TreeNode.New(SystemDocumentTypes.MenuItem, tree);
 
    // Sets the properties of the new page
    newPage.DocumentName = "Articles";
    newPage.DocumentCulture = "en-us";
 
    // Inserts the new page as a child of the parent page
    newPage.Insert(parentPage);
