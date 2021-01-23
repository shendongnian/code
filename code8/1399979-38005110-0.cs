    var pageHandler = HttpContext.Current.CurrentHandler;
    Control ctrlHull = ((Page)pageHandler).Master.FindControl("imgbtnHull");
    if(ctrlHull !=null)
    {
       ImageButton imgBtnHull = (ImageButton)ctrlHull;
       // Proceed with imgBtnHull 
    }
