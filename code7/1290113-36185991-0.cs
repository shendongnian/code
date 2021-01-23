    var branchpath = "your/branch/template/path";
    using (new SecurityDisabler())
    {
       var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
       
       Item parentItem = masterDb.Items["path/to/parent/item/here"];
       BranchItem template = masterDb.GetItem(branchpath);
       parentItem.Add("YourItemName", template);
    }
