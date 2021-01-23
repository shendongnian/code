    List<Func<TestResult>> methods = new List<Func<TestResult>>() { TestMethod1, TestMethod2, TestMethod3 };
    
    foreach(var f in methods)
    {
        if(f().Result != EmptyResult)
        {
            break; //or something else
        }
    }
