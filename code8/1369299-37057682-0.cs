    var dict = new Dictionary<object, object(new TestsAndWrappersAreEqualComparer());
    var test = Test.GetInstance(true);
    var testWrapper = TestWrapper.GetInstance(true);
    dict[test] = test;
    Console.WriteLine(dict.ContainsKey(test)); // true
