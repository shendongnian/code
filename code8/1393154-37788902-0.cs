    var latestTests = new Dictionary<string, Test>(tests.Count);
    foreach (Test t in tests)
    {
        Test test;
        if (latestTests.TryGetValue(t.Name, out test) && test.Date < t.Date)
        {
            latestTests[t.Name] = test;
        }
        else
        {
            latestTests.Add(t.Name, t);
        }
    }
    tests = latestTests.Values.ToList();
