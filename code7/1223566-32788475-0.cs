    public static WinWindow _mainParent(string MainParentCtlName)
        {
            var _mainForm = new WinWindow();
            _mainForm.SearchProperties.Add("ControlName", MainParentCtlName);
            return _mainForm;
        }
    public static void CloseWindow(string MainWinCtlName)
        {
            var close = new WinButton(_mainParent(MainWinCtlName));
            close.SearchProperties.Add("Name", "Close");
            Mouse.Click(close);
        }
    try
    {CloseWindow("MainWindowForm")}
    catch{}
