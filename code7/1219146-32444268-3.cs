    for(int i = 0; i < submittedTest.Count - 1; i++)
    {
    if(submittedTest[i].Name == tempName)
        {
            //Remove correct test from submittedTest que
            submittedTest.Dequeue();
            //Add correct test to a new array, outForChecking
            outForChecking.Push(submittedTest[i]);
            //Tester to validate how many items are left in the submittedTest que
            Console.WriteLine("{0}", submittedTest.Count);
        }
    }
  
