    Test myTest = t as Test;
    if (myTest != null)
    {
       Console.WriteLine(myTest.sub());
    }
    else
    {
        Console.WriteLine("t cannot be converted to type Test");
    }
