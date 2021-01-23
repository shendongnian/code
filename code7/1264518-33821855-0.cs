    object testObj;
    foreach (var test in Tests)
    {
         testObj = new object();  // creates a new instance every iteration
         //Set some properties of the object
         Thread t = new Thread(() => manager(testObj));  
         t.Start();
    }
    // do anything with the lastly created instance
    DoSomething(testObject);
