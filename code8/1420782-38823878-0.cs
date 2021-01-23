    UITestControl AM = new UITestControl(browser);
    //AM.TechnologyName = "Web";            
    //AM.SearchProperties.Add("Inner Text", "Alert Me");
    AM.SearchProperties.Add("Id", "Ribbon.Library.Share.AlertMe-Large");
    AM.WaitForControlReady();
    UITestControlCollection uic=AM.FindMatchingControls();
    foreach(UITestControl ui in uic)
    {
    if(ui.BoundingRectangle.Width !=-1)
    {
    Mouse.Click(ui);
    break;
    }
    }
