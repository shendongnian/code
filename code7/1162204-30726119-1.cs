    public ActionResult MyAction
    {
        string data; // remember this will be null, not "" by default
        try
        {
            data = ProcessString("some data");
        }
        catch (OwlMisalignedException ex)
        {
            return RedirectToAction("Index", "Error", new { exData = ex.Code });
        }
        // proceed with controller as normal
    }
    public string ProcessString(string input)
    {
        if (condition) 
        {
            throw new OwlMisalignedException(1234);
            // this is (obviously) a made up exception with a Code property 
            // as an example of passing the error code back up to an error 
            // handling page, for example.
        }
        string output = input + "!"; // or whatever you need to do!
        return input;
    }
