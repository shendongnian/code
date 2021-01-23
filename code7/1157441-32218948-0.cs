    public static IEnumerable<object[]> GetClients()
    {
        yield return new object[] { new Impl.Client("clientType1") };
        yield return new object[] { new Impl.Client("clientType2") };
    }
    [Theory]
    [MemberData(nameof(GetClients))]
    public void ClientTheory(Impl.Client testClient)
    {
        // ... test here
    }
