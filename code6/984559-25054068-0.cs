    public void CreateCallenderItem_click(IRibbonControl control)
    {
    	// Get selected calendar date
        Outlook.Application application = new Outlook.Application();
        Outlook.Explorer explorer = application.ActiveExplorer();
        Outlook.Folder folder = explorer.CurrentFolder as Outlook.Folder;
        Outlook.View view = explorer.CurrentView as Outlook.View;
    
        if (view.ViewType == Outlook.OlViewType.olCalendarView)
        {
            Outlook.CalendarView calView = view as Outlook.CalendarView;
            DateTime calDateStart = calView.SelectedStartTime;
            DateTime calDateEnd = calView.SelectedEndTime;
    
            // Do stuff with dates. 
        }
    }
