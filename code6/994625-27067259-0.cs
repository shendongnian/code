    // VersionControlExt is needed 
    var dte = Package.GetGlobalService(typeof(DTE)) as DTE;
    var dte2 = (DTE2)dte;
    var vce = dte2.DTE.GetObject("Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExt")
          as VersionControlExt;
    var pendingChangesExtField = vce.PendingChanges.GetType().GetField("m_pendingChangesExt", BindingFlags.Instance | BindingFlags.NonPublic);
    var pendingChangesExt = pendingChangesExtField.GetValue(vce.PendingChanges);
    // pendingChangesExt is null when the Pending Changes Window isn't opened
    if (pendingChangesExt == null)
      return;
    var workItemSectionField = pendingChangesExt.GetType().GetField("m_workItemsSection", BindingFlags.Instance | BindingFlags.NonPublic);
    var workItemSection = workItemSectionField.GetValue(pendingChangesExt); 
    // Assign new Work Item to Pending Changes
    var addMethod = workItemSectionField.FieldType.GetMethod("AddWorkItemById", BindingFlags.Instance | BindingFlags.NonPublic);
        object[] addArray = { id };
    addMethod.Invoke(workItemSection, addArray);
