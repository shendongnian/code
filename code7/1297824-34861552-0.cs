    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    
    ...
    
    DTE2 ide = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2);
    CommandEvents commandEvents = ide.Events.CommandEvents;
    commandEvents.BeforeExecute += OnBeforeExecute;
    commandEvents.AfterExecute += OnAfterExecute;
    
    ...
    
    private void OnBeforeExecute(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
    {
        if (ID == (int)VSConstants.VSStd97CmdID.RebuildCtx)
        {
            // Do something
        }
    }
    
    private void OnAfterExecute(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
    {
        if (ID == (int)VSConstants.VSStd97CmdID.RebuildCtx)
        {
            // Do something
        }
    }
