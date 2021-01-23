    private static IEnumerable<Request> GetExternalRequests()
    {
        yield return new Request(new DateTime(2015, 1, 4), new DateTime(2015, 1, 4), 1);
        yield return new Request(new DateTime(2015, 1, 5), new DateTime(2015, 1, 5), 1);
        yield return new Request(new DateTime(2015, 1, 6), new DateTime(2015, 1, 6), 1);
        yield return new Request(new DateTime(2015, 1, 7), new DateTime(2015, 1, 7), 1);
        yield return new Request(new DateTime(2015, 1, 8), new DateTime(2015, 1, 8), 1);
        yield return new Request(new DateTime(2015, 1, 11), new DateTime(2015, 1, 11), 1);
        yield return new Request(new DateTime(2015, 1, 15), new DateTime(2015, 1, 15), 1);
        yield return new Request(new DateTime(2015, 1, 19), new DateTime(2015, 1, 19), 1);
        yield return new Request(new DateTime(2015, 1, 26), new DateTime(2015, 1, 26), 1);
        yield return new Request(new DateTime(2015, 1, 4), new DateTime(2015, 1, 4), 2);
        yield return new Request(new DateTime(2015, 1, 7), new DateTime(2015, 1, 7), 2);
    }
