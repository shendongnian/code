    var Driver = new InternetExplorerDriver();
    //first page - click
    Driver.Instance.FindElement(By.Id("submit-button")).Click();
    Stopwatch s = Stopwatch.StartNew();
    //set waiting period
    Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
    //second page - wait for element to be available.
    var element = Driver.Instance.FindElement(By.Id("id-on-second-page"));
    //stop timer
    s.Stop();
    //reset waiting period
    Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
    Console.WriteLine("Elapsed Time: {0} ms", s.ElapsedMilliseconds);
