    var latestTests = new Dictionary<string, Test>(tests.Count);
    foreach (Test t in tests)
    {
        Test test;
        if (latestTests.TryGetValue(t.Name, out test))
        {
            if(test.Date < t.Date)
                latestTests[t.Name] = t;
        }
        else
        {
            latestTests.Add(t.Name, t);
        }
    }
    tests = latestTests.Values.ToList();
