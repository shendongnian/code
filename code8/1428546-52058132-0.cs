    public void RemoveErrors(IVsHierarchy aHierarchy)
    {
      SuspendRefresh();
      for (int i = errorListProvider.Tasks.Count - 1; i >= 0; --i)
      {
        var errorTask = errorListProvider.Tasks[i] as ErrorTask;
        aHierarchy.GetCanonicalName(Microsoft.VisualStudio.VSConstants.VSITEMID_ROOT, out string nameInHierarchy);
        errorTask.HierarchyItem.GetCanonicalName(Microsoft.VisualStudio.VSConstants.VSITEMID_ROOT, out string nameErrorTaskHierarchy);
        if (nameInHierarchy == nameErrorTaskHierarchy)
        {
          errorTask.Navigate -= ErrorTaskNavigate;
          errorListProvider.Tasks.Remove(errorTask);
        }
      }
      ResumeRefresh();
    }
