    public ActionResult MyAction
    {
        string data = ProcessString("some data");
        if (data == null) { return Redirect("google.com"); }
    }
    public string ProcessString(string input)
    {
        if (condition) { return null; }
        string output = input + "!"; // or whatever you need to do!
        return input;
    }
