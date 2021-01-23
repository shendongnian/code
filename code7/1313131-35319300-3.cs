    //Getting the processes, running through a foreach
    //...
    //Inside the foreach
    int dwExStyle    = GetWindowLong(p.MainWindowHandle, GWL_EXSTYLE);
    
    string isTopMost = "No";
    if ((dwExStyle & WS_EX_TOPMOST) != 0)
    {
        isTopMost = "Yes";
    }
    ListViewItem wlv = new ListViewItem(isTopMost, 1);
    wlv.SubItems.Add(p.Id.ToString());
    wlv.SubItems.Add(p.ProcessName);
    wlv.SubItems.Add(p.MainWindowTitle);
    windowListView.Items.Add(wlv);
    //Some sortingthings for the listview
    //end of foreach processes
