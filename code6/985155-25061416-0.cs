    // Run the test like you're currently doing
    NUnit.ConsoleRunner.Runner.Main(new string[]
    {
       System.Reflection.Assembly.GetExecutingAssembly().Location,
       "OpenShop.dll",                   
    });
    // Save the file to match the name of the assembly, and so it is not
    // overwritten on each run
    File.Copy("TestResult.xml", "OpenShop-TestResult.xml");
