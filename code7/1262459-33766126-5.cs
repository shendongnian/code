    public void NextTab()
    {
        if (CurrentTabIndex == Tabs.Count - 1)
            return; // on last tab already
        CurrentTabIndex++;
        // if user is on last enabled tab
        if (CurrentTabIndex == MaxTabIndex)
        {
            MaxTabIndex++;
            Progress += 100 / Tabs.Count;
        }
    }
