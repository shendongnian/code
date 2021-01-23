    var signatures = dataContext.CM_Signatures.Where(c => c.ParagraphID == RowID).ToList();
    if (signatures.Any())
    {
        foreach (var sig in signatures)
        {
            if (sig.LoginName.ToLower() == web.CurrentUser.LoginName.ToLower())
            {
                return false;
            }
            else
                return true;
        }    
    }
    else
    {
        return true;
    }      
