    // Get the page that is handling the current request.
    var pageHandler = HttpContext.Current.CurrentHandler;
    // Find the control named "imgbtnHull" on the master page.
    Control ctrlHull = ((Page)pageHandler).Master.FindControl("imgbtnHull");
    // Cast the control to type ImageButton.
    ImageButton imgBtnHull = (ImageButton)ctrlHull;
