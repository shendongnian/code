    bool hasAtLeastOneFalse = false;
    if (qualificationCheckCallback != null)
    {
        foreach(var f in qualificationCheckCallback.GetInvocationList()
                                                   .Cast<Func<Employee, Shift, bool>>())
        {
            if (!f(employee, shift))
            {
                hasAtLeastOneFalse = true;
                // break; // If you don't care about invoking all delegates, you can choose to break here.
            }
        }
    }
    Console.WriteLine(hasAtLeastOneFalse);
