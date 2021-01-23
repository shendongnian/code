    foreach (myEvent item in DB.Events)
    {
        if (!item.IsDeleted && string.IsNullOrEmpty(item.GoogleID))
        {
            // Create new Google Event from DB event
        }
        else if (!item.IsDeleted && !string.IsNullOrEmpty(item.GoogleID))
        {
            // Mark DB event as deleted
            item.IsDeleted = true;
        }
    }
