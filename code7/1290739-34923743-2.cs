    private string testString = "test";
    [ContractInvariantMethod]
    private void TestInvariant()
    {
         Contract.Invariant(!string.IsNullOrWhiteSpace(testString));
    }
