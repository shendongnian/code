        IStaticTestSuite testSuite = itmtp.TestSuites.CreateStatic();
        foreach (IStaticTestSuite ts in itmtp.TestSuites.Query("Select * From TestSuite"))
        {
            if (ts.Id == 103)//Get the test suite by ID
            {
                testSuite = ts;
            }
        }
        IStaticTestSuite mtmTestSuite = itmtp.TestSuites.CreateStatic();
        mtmTestSuite.Title = "Title";
        testSuite.Entries.Add(mtmTestSuite);
