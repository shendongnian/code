    [TestInitialize]
    public void GivenTimeConsumingPreConditions()
    {
       // do time consuming steps
    }
    [TestMethod]
    public void WhenManipulatingTabs_ThenSearchFiltersResults()
    {
        // depending on how you want to iterate, this is a super simple example
        string[] tabs = new ["Products", "Customers"];
        
        List<Exception> exs = new List<Exception>(tabs.Length);
        foreach(string tabName in tabs){
            OpenTab(tabName);
            EnterTextIntoSearchBox("test");
            ClickSearch();
            try {
                Assert.IsTrue(AllResultsContain("test"));
            } catch(Exception e) {
                exs.Add(e);
            }
        }
        if(exs.Any()){
            throw new AggregateException(exs);
        }
    }
