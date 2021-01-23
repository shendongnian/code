    public void TestIt(out string testVar)
    {
       Debug.WriteLine(testVar);
       testVar = "This was a test.";
    }
    private string test = "this is a test.";
    TestIt(out test);
    Debug.WriteLine(test);
    // Output:
    // This is a test.
    // This was a test.
