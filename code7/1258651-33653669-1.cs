    private void SelectedTestCaseChanged(object obj)
    {
        if (obj is TestCase)
        {
            var testCase = (TestCase)obj;
            // Work with testCase
        }
    
        if (obj is string)
        {
            // Do nothing or whatever
        }
    
        // Another option is
        var testCase = obj as TestCase;
        if (testCase != null)
        {
            //...
        }
    }
