    // here we say session clear just for the TEST purposes below
    session.Clear();
    // now, session is closed, no lazy loading, but due to JOIN ALIAS
    // the PrintJobType is loaded as well
    Assert.IsTrue(result != null);
    Assert.IsTrue(result.PrintJobType != null);
    Assert.IsTrue(result.PrintJobType.PriorityWeight != null);
