    SelectElement SelectEmployeeName = new SelectElement(driver.FindElement(By.Id("ps_ck$0")));
    //To count elements
    IList<IWebElement> ElementCount = SelectEmployeeName.Options;
    int NumberOfItems = ElementCount.Count;
    Console.WriteLine("Size of BGL: " + NumberOfItems);
    //Getting drop down values
    for(int i = 0; i < NumberOfItems; i++)
    {
    String DropDownItems = ElementCount.ElementAt(i).Text;
    Console.WriteLine(DropDownItems);
    }
