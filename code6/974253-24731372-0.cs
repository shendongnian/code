    [Test]
    public void ShouldRetrieveItemsFromDatabase(){
        List<UserDetails> expected = BuildExpectedList();
        List<UserDetails> actual = GetUsersListForAllLocation();
        CollectionAssert.AreEquivalent(expected, actual);
    }
