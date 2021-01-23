    private void AddButton(CommandBar popupCommandBar)
    {
        bool isFound = false;
		foreach (object _object in popupCommandBar.Controls)
		{
			CommandBarButton _commandBarButton = _object as CommandBarButton;
			if (_commandBarButton == null) continue;
			if (_commandBarButton.Tag.Equals("HELLO_TAG"))
			{
				isFound = true;
				System.Diagnostics.Debug.WriteLine
		("Found existing button. Will attach a handler.");
				commandBarButton.Click += eventHandler;
				break;
			}
		}
		if (!isFound)
		{
			commandBarButton = (CommandBarButton)popupCommandBar.Controls.Add
	(MsoControlType.msoControlButton, missing, missing, missing, true);
			System.Diagnostics.Debug.WriteLine("Created new button, adding handler");
			commandBarButton.Click += eventHandler;
			commandBarButton.Caption = "Hello !!!";
			commandBarButton.FaceId = 356;
			commandBarButton.Tag = "HELLO_TAG";
			commandBarButton.BeginGroup = true;
		}
    }
    // add the button to the context menus that you need to support
    AddButton(applicationObject.CommandBars["Text"]);
    AddButton(applicationObject.CommandBars["Table Text"]);
    AddButton(applicationObject.CommandBars["Table Cells"]);
    
