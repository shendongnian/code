    try
    {
    ...
    }
    catch(WebDriverException exception)
    {
        Console.Writeline("Defect in Application - Failed due to Selenium Exception");
    }
    catch(Exception ex)
    {
        Console.Writeline("Coding Error - Exception raised in code");
    }
