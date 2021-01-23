    string usernameWhoHasLock = (string)Cache["PageIsLockedByUser"];
    if (usernameWhoHasLock  == null)
    {
      // Page is not locked, lock it:
      usernameWhoHasLock = HttpContext.Current.Identity.Name;
      Cache.Insert("PageIsLockedByUser", isLocked, null, EXPIRYDETAILS);
    }
    else
    {
       // Page is locked. If IsPostback, allow edits if is the user with the lock, otherwise return an error. If not postback, disable the edit button unless is the user with the lock.
    }
