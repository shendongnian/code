    private static bool WasFirstTimeReleased = false;
    if (Input.GetMouseButtonUp(0))
    {
        if (!WasFirstTimeReleased)
        {
            WasFirstTimeRelease = true;
            //do your stuff for first time
        }
        else
        {
            //do your stuff for all other times
        }
    }
