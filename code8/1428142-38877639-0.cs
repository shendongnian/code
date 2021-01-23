    WinClient OrderRows= UIApp.UIItemWindow.UIItemTable.UIDataPanelClient;
    UITestControlCollection count = OrderRows.GetChildren();
    var a = count.Count;
    Console.WriteLine("Number of Rows: {0}", count);
    Output: 
    Number of Rows: 456
