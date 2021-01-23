    Task<string> result = SomeHardWorkAsync();
    Debug.WriteLine("After calling SomeHardWorkAsync");
    DoSomeOtherWorkInTheMeantime();
    Debug.WriteLine("Done other work.");
    
    Debug.WriteLine("Got result: " + (await result));
