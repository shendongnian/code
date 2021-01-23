    int curLevel = 0;
    public void MyLogInfo( bool enter, [System.Runtime.CompilerServices.CallerMemberName] string callingMethod = "", )
    {
        string prefix;
        if (enter)
        {
          prefix = "> ";
          curLevel++;
        }
        else
        {
          prefix = "< ";
          curLevel--;
        }
        logger.info(prefix.PadLeft(curLevel+prefix.Length) + callingMethod;
    }
