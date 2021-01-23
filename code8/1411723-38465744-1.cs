    public void FileSave_OnAction(Office.IRibbonControl control, bool cancelDefault)
    {
        using (var document = new ComWrapper<PowerPoint.Presentation>(Globals.ThisAddIn.Application.ActivePresentation))
        using (var docWrapper = DocWrapper<PowerPoint.Presentation>.GetWrapper(document))
        {
            try
            {
                cancelDefault = true;
                docWrapper.SaveAsUI = false;
                docWrapper.Save();
            }
            finally
            {
                docWrapper.SaveAsUI = true;
            }
        }
    }
