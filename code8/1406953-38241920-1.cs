    ServerOperations.client.LoginOptions.URL = url;
    ServerOperations.client.LoginOptions.User = user;
    ServerOperations.client.LoginOptions.Password = pass;
    ServerOperations.client.LoginOptions.Repository = rep;
    ServerOperations.Login();
    ServerOperations.client.AutoCommit = true;
    string prjPath = "$/projectpath";
    VaultLabelItemX[] arLabelItems = null;
    
    int nRetCode = ServerOperations.ProcessCommandFindLabels("*", prjPath, false, 1000, true, true, VaultFindInFilesDefine.PatternMatch.Wildcard, out arLabelItems);
    
    MessageBox.Show(arLabelItems.Count().ToString()); // Print how much labels found
    
    foreach (var item in arLabelItems)
    {
       MessageBox.Show(arLabelItems[i].Label.ToString()); // Show Label 
    }
