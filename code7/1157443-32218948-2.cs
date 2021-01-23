    public static IEnumerable<object[]> GetClients()
    {
        yield return new object[] { new TestClientBuilder("clientType1") };
        yield return new object[] { new TestClientBuilder("clientType2") };
    }
    [Theory]
    [MemberData(nameof(GetClients))]
    private void ClientTheory(TestClientBuilder clientBuilder)
    {
        var client = clientBuilder.Build();
        // ... test here
    }
