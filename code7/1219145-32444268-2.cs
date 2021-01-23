     foreach (Test tests in submittedTest)
    {
        if(tests.Name == tempName)
        {
            //Remove correct test from submittedTest que
            submittedTest.Dequeue();
            //Add correct test to a new array, outForChecking
            outForChecking.Push(tests);
            //Tester to validate how many items are left in the submittedTest que
            Console.WriteLine("{0}", submittedTest.Count);
        }
    }
