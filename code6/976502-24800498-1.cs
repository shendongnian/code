    OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    if (null != mcs)
    {
       // Create the command for the menu item.
       CommandID menuCommandID = new CommandID(GuidList.guidToolbarCmdSet, (int)PkgCmdIDList.cmdidButton0);
       var menuItem = new OleMenuCommand(MenuItemCallback, menuCommandID);
       menuItem.BeforeQueryStatus += BeforeQueryStatusCallback;
       mcs.AddCommand(menuItem);
    }
