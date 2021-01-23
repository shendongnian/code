    public void AddFilePaths(List<string> paths)
    {
    	if (paths.Count > 0)
    	{
    		MailItem  mi = ThisAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
    		mi.Display();
    		if (mi!= null)
    		{
    			foreach (var path in paths)
    			{
    				AddPathsToNewEmailMessage(path);
    			}
    		}
    	}
    }
