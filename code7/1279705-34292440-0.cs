    public void TestIt(out testVar)
    {
       Debug.WriteLine(testVar);
       testVar = "This was a test.";
    }
    private string test = "this is a test.";
    TestIt(out test);
    Debug.WriteLine(test);
