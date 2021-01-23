    private bool IsStatusChangeValid(CommandResult result)
    {
        var file = FileViews.FileGet(fileId);
    
        // LOOP THAT CHECKS IF STATUS IS CHANGED TO "VOIDED"
        // THEN NOTIFIES USER IF THERE ARE NON-VOIDED ITEMS IN FILE
        foreach (var item in file.FileItems)
        {
            item.File = file;
    
            // ONLY IF ITEMS EXIST
            if (item.ItemCode.Length > 0)
            {
                // CHECK IF STATUS IS CHANGED TO "VOIDED"
                if (newDescription.Equals("Voided"))
                {
                    if (item.ItemStatusID != ItemStatusIDConstants.Voided)
                    {
                        result.Success = false;
                    }
                    return result.Success;
                }
            }
        }
        return true;
    }
