    bool done = false;
    foreach (Thing bar in something)
    {
        foreach (Collection item in bar.Stuff)
        {
            Data dataRX = item.First;
            if (dataRX != null && dataRX.ID.Equals(globalNonsense.ID))
            {
                // Update Data with the latest changes
                dataRX.fooBuddy = foo;
                done = true;
                break;
            }
        }
        
        if(done)
            break;
    }
