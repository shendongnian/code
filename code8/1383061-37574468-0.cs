    WinToolBar notificationBar = new WinToolBar(browserWindow);
    notificationBar.SearchProperties.Add(WinToolBar.PropertyNames.Name, "Notification", PropertyExpressionOperator.EqualTo);
    WinSplitButton saveButton = new WinSplitButton(notificationBar);
    saveButton.SearchProperties.Add(WinButton.PropertyNames.Name, "Save", PropertyExpressionOperator.EqualTo);
    Mouse.Click(saveButton);
