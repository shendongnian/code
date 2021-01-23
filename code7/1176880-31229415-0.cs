    private void CreateContextMenu()
    {
        // Get a reference to the context menu of code windows.
        CommandBars commandBars = (CommandBars)applicationObject.CommandBars;
        CommandBar codeWindowCommandBar = commandBars["Code Window"];
    
        // Add a popup command bar.
        CommandBarControl myCommandBarControl = codeWindowCommandBar.Controls.Add(MsoControlType.msoControlPopup,
            System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
    
        CommandBarPopup myPopup = (CommandBarPopup)myCommandBarControl;
    
        // Change its caption
        myPopup.Caption = "My popup";
    
        // Add controls to the popup command bar
        CommandBarButton myButton = (CommandBarButton)myPopup.Controls.Add(MsoControlType.msoControlButton, Missing.Value, Missing.Value, 1, true);
        myButton.Caption = "Click Me";
        myButton.Click += myButton_Click;
    }
    
    void myButton_Click(CommandBarButton Ctrl, ref bool CancelDefault)
    {
        MessageBox.Show("What's up?");
    }
