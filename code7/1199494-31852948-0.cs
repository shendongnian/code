    var dte2 = (EnvDTE80.DTE2)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE));
    Microsoft.VisualStudio.OLE.Interop.IServiceProvider sp = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)dte2;
    Microsoft.VisualStudio.Shell.ServiceProvider serviceProvider = new Microsoft.VisualStudio.Shell.ServiceProvider(sp);
    
    Microsoft.VisualStudio.Shell.Interop.IVsUIHierarchy uiHierarchy;
    uint itemID;
    Microsoft.VisualStudio.Shell.Interop.IVsWindowFrame windowFrame;
    Microsoft.VisualStudio.Shell.VsShellUtilities.IsDocumentOpen(serviceProvider, _iTextDocument.FilePath, Guid.Empty, out uiHierarchy, out itemID, out windowFrame);
    
    windowFrame.CloseFrame((uint)__FRAMECLOSE.FRAMECLOSE_NoSave);
