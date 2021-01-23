    private void moveTheScroll(object sbar, int scrollDiff)
    {
        var scrollBar = sbar as ScrollBar;
        if(scrollBar != null)
        {
             int newScrollvalue = scrollBar.Value + scrollDiff;
             // do other works with scrollBar...
        }
    }
