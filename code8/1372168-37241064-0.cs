    var wgEnumerable = await voteDictionary.CreateEnumerableAsync(tx);
    using(IAsyncEnumerator<KeyValuePair<string, int>> enumerator = wgEnumerable.GetAsyncEnumerator())
    {
    while(await enumerator.MoveNextAsync(CancellationToken.None))
    {
    //Do something
    }
    }
