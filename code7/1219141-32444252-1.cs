    for (int i = submittedTest.Count-1; i>=0; i--)
    {
        var tests = submittedTest[i];
        if(tests.Name == tempName)
        {
            //Remove correct test from submittedTest que
            submittedTest.Remove(tests);
    
            //Add correct test to a new array, outForChecking
            outForChecking.Push(tests);
    
            //Tester to validate how many items are left in the submittedTest que
            Console.WriteLine("{0}", submittedTest.Count);
        }
    }
