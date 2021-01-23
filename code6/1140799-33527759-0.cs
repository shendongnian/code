    private void RetryWorkItemSave(WorkItem workItem)
    {
            //Get the non-computed dirty fields from the failed update
            var dirtyFields = workItem.Fields.Cast<Field>()
                      .Where(w => w.IsDirty && !w.IsComputed)
                      .ToDictionary((f) => f.ReferenceName, (f) => f.Value); 
            //Sync the work item to the latest version
            workItem.SyncToLatest();
            //Reapply the original field changes
            foreach (var field in dirtyFields)
            {
                if (workItem.Fields[field.Key].IsEditable)
                {
                    workItem[field.Key] = field.Value;
                }
            }
            workItem.Save(SaveFlags.MergeAll);
    }
