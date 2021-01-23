    private void SaveIDsToEditingItem(Item editingItem, IEnumerable<ID> guidList, bool forceModified)
    {
        Field redirectedToFromItemId = editingItem.Fields["301RedirectedToFromItemId"];
    
        using (new EventDisabler())
        {
            using (new EditContext(editingItem))
            {
                // Saving the redirected items ids
                string redirectedToFromItemIdOld = redirectedToFromItemId.Value;
                string redirectedToFromItemIdNew = string.Join("\n", guidList.Select(guid => guid.ToString()));
    
                // if the values are not changed
                if (redirectedToFromItemIdNew.Equals(redirectedToFromItemIdOld))
                {
                    return;
                }
    
                redirectedToFromItemId.Value = redirectedToFromItemIdNew;
                if (forceModified)
                {
                    editingItem.RuntimeSettings.ForceModified = true;
                }
            }
        }
    }
