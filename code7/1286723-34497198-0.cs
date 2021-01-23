    Employee employee = null; // assign something here
    Shift shift = null; // assign something here
    bool hasAtLeastOneFalse;
    
    if (qualificationCheckCallback == null)
    {
        hasAtLeastOneFalse = false;
    }
    else
    {
        hasAtLeastOneFalse = qualificationCheckCallback
            .GetInvocationList().Any(d => !((Func<Employee, Shift, bool>)d)());
    }
    
    Console.WriteLine(hasAtLeastOneFalse);
