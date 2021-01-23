    private static IEnumerable<Request> GetExternalRequests()
    {
        yield return new Request(DateTime.Now.AddDays(0), DateTime.Now.AddDays(0), 1);
        yield return new Request(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), 1);
        yield return new Request(DateTime.Now.AddDays(2), DateTime.Now.AddDays(2), 1);
        yield return new Request(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3), 1);
        yield return new Request(DateTime.Now.AddDays(4), DateTime.Now.AddDays(4), 1);
        yield return new Request(DateTime.Now.AddDays(0), DateTime.Now.AddDays(0), 2);
        yield return new Request(DateTime.Now.AddDays(3), DateTime.Now.AddDays(3), 2);
    }
