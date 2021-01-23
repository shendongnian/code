    List<string> list = new List<string>(); 
    VaultClientCheckOutList chList = ServerOperations.ProcessCommandListCheckOuts();
    foreach (var item in chList.Cast<VaultClientCheckOutItem>().ToList())
    {
        foreach (var file in item.CheckOutUsers)
        list.Add(file.LocalPath);
    }
