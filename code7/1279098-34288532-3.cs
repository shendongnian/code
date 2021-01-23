    private void AddButton(CommandBar popupCommandBar)
    {
        bool isFound = false;
		foreach (var commandBarButton in popupCommandBar.Controls.OfType<CommandBarButton>())
		{
			if (commandBarButton.Tag.Equals("HELLO_TAG"))
			{
				isFound = true;
				Debug.WriteLine("Found existing button. Will attach a handler.");
				commandBarButton.Click += eventHandler;
				break;
			}
		}
		if (!isFound)
		{
			var commandBarButton = (CommandBarButton)popupCommandBar.Controls.Add
	            (MsoControlType.msoControlButton, missing, missing, missing, true);
			Debug.WriteLine("Created new button, adding handler");
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
    
