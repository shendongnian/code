    var journal = regionNavigationService.Journal as RegionNavigationJournal;
    if (journal != null)
    {
        var stack =
            (Stack<IRegionNavigationJournalEntry>)
            typeof (RegionNavigationJournal).GetField("backStack",
                                                      BindingFlags.NonPublic | BindingFlags.Instance)
                                            .GetValue(journal);
        
        var name = stack.Peek().Uri.OriginalString;
    }
