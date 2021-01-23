    private static bool IsSingleProjectItemSelection(out IVsHierarchy hierarchy, out uint itemid)
        {
            hierarchy = null;
            itemid = VSConstants.VSITEMID_NIL;
            int hr = VSConstants.S_OK;
            var monitorSelection = Package.GetGlobalService( typeof( SVsShellMonitorSelection ) ) as IVsMonitorSelection;
            var solution = Package.GetGlobalService( typeof( SVsSolution ) ) as IVsSolution;
            if (monitorSelection == null || solution == null)
                return false;
            IVsMultiItemSelect multiItemSelect = null;
            IntPtr hierarchyPtr = IntPtr.Zero;
            IntPtr selectionContainerPtr = IntPtr.Zero;
            try
            {
                hr = monitorSelection.GetCurrentSelection( out hierarchyPtr, out itemid, out multiItemSelect, out selectionContainerPtr );
                if (ErrorHandler.Failed( hr ) || hierarchyPtr == IntPtr.Zero || itemid == VSConstants.VSITEMID_NIL)
                    return false;
                // multiple items are selected
                if (multiItemSelect != null)
                    return false;
                // there is a hierarchy root node selected, thus it is not a single item inside a project
                if (itemid == VSConstants.VSITEMID_ROOT)
                    return false;
                hierarchy = Marshal.GetObjectForIUnknown( hierarchyPtr ) as IVsHierarchy;
                if (hierarchy == null)
                    return false;
                Guid guidProjectID = Guid.Empty;
                if (ErrorHandler.Failed( solution.GetGuidOfProject( hierarchy, out guidProjectID ) ))
                    return false;
                // if we got this far then there is a single project item selected
                return true;
            }
            finally
            {
                if (selectionContainerPtr != IntPtr.Zero)
                    Marshal.Release( selectionContainerPtr );
                if (hierarchyPtr != IntPtr.Zero)
                    Marshal.Release( hierarchyPtr );
            }
        }
    IVsHierarchy hierarchy = null;
                    uint itemid = VSConstants.VSITEMID_NIL;
                    if (!IsSingleProjectItemSelection(out hierarchy, out itemid))
                        return;
                    string itemFullPath = null;
                    ((IVsProject)hierarchy).GetMkDocument(itemid, out itemFullPath);
                    if (itemFullPath.EndsWith(".cs"))
