    if (existingCaseItem == null)
    {
        throw new FaultException<AtcWcfEntryNotFoundException>(
            new AtcWcfEntryNotFoundException(caseItem.InventoryItem.GetType(),
            caseItem.InventoryItem.Id));
    }
