    public static void SetButtons(params ButtonType[] buttonTypes)
    {
        var buttons = buttonTypes.Select(ButtonFactory.CreateButton);
        // add buttons to UI
    }
