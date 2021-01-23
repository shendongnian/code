    private bool IsStatusChangeValid(CommandResult result)
    {
        bool isStatusChangeValid = true
        var file = FileViews.FileGet(fileId);
    
        foreach (var item in file.FileItems)
        {
            item.File = file;
    
            if (item.ItemCode.Length > 0)
            {
                if (newDescription.Equals("Voided"))
                {
                    if (item.ItemStatusID != ItemStatusIDConstants.Voided)
                    {
                        result.Success = false;
                    }
                    isStatusChangeValid = false
                    break;
                }
            }
        }
        return isStatusChangeValid;
    }
